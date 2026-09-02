using DTOs;
using Data;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return new LoginResponse { Exito = false, Mensaje = "Faltan completar datos." };
            }

            var usuario = await _usuarioRepository.ObtenerPorUsernameAsync(request.Username);

            if (usuario == null)
            {
                return new LoginResponse { Exito = false, Mensaje = "Usuario o contraseña incorrectos." };
            }

            if (usuario.Password != request.Password)
            {
                return new LoginResponse { Exito = false, Mensaje = "Usuario o contraseña incorrectos." };
            }

            return new LoginResponse
            {
                Exito = true,
                Mensaje = "Login correcto",
                Username = usuario.Username
            };
        }
    }
}