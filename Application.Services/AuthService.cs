using DTOs;
using Data;
using Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly ControlIntentosLogin _controlIntentos;

        public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration, ControlIntentosLogin controlIntentos)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
            _controlIntentos = controlIntentos;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return new LoginResponse { Exito = false, Mensaje = "Usuario y contraseña requeridos" };

            if (request.Username.Length > 50 || request.Password.Length > Validador.LargoMaximoPassword)
                return new LoginResponse { Exito = false, Mensaje = "Usuario o contraseña incorrectos" };

            // Se controla antes de verificar la contraseña, así durante el bloqueo no se puede seguir probando
            if (_controlIntentos.TiempoRestanteBloqueo(request.Username) is TimeSpan restante)
                return Bloqueado(restante);

            var usuario = await _usuarioRepository.ObtenerPorUsernameAsync(request.Username.Trim());

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
            {
                // Se cuenta aunque el usuario no exista, para no revelar qué usernames son válidos
                int intentosRestantes = _controlIntentos.RegistrarFallo(request.Username);

                if (intentosRestantes == 0)
                    return Bloqueado(ControlIntentosLogin.DuracionBloqueo);

                return new LoginResponse
                {
                    Exito = false,
                    Mensaje = $"Usuario o contraseña incorrectos. Te quedan {intentosRestantes} intento(s) antes de que la cuenta se bloquee temporalmente."
                };
            }

            _controlIntentos.RegistrarExito(request.Username);

            var token = GenerateJwtToken(usuario);
            var expiresAt = DateTime.UtcNow.AddMinutes(GetExpirationMinutes());

            return new LoginResponse
            {
                Exito = true,
                Mensaje = "Login exitoso",
                Token = token,
                ExpiresAt = expiresAt,
                Username = usuario.Username,
                Rol = usuario.Rol
            };
        }

        private static LoginResponse Bloqueado(TimeSpan restante)
        {
            int minutos = Math.Max(1, (int)Math.Ceiling(restante.TotalMinutes));

            return new LoginResponse
            {
                Exito = false,
                Bloqueado = true,
                Mensaje = $"Demasiados intentos fallidos. La cuenta quedó bloqueada temporalmente: volvé a intentar en {minutos} minuto(s)."
            };
        }

        private string GenerateJwtToken(Usuario usuario)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()), 
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim("jti", Guid.NewGuid().ToString())
            };

            if (!string.IsNullOrEmpty(usuario.Rol))
            {
                claims.Add(new Claim(ClaimTypes.Role, usuario.Rol));
            }

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(GetExpirationMinutes()),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            try
            {
                var jwtSettings = _configuration.GetSection("JwtSettings");
                var secretKey = jwtSettings["SecretKey"];
                var issuer = jwtSettings["Issuer"];
                var audience = jwtSettings["Audience"];

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));

                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ClockSkew = TimeSpan.Zero
                };

                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken _);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int? GetUserIdFromToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jsonToken = tokenHandler.ReadJwtToken(token);

                var userIdClaim = jsonToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    return userId;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        private int GetExpirationMinutes()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            if (int.TryParse(jwtSettings["ExpirationMinutes"], out int minutes))
                return minutes;
            return 60;
        }
    }
}