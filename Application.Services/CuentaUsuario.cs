using Data;
using Domain.Model;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    // Lógica común del usuario asociado a un socio, profesor o administrador
    internal static class CuentaUsuario
    {
        // Si no se indican, el username y la contraseña inicial son el DNI
        public static Usuario Crear(string dni, string? username, string? email, string? password, string rol)
        {
            bool passwordIndicada = !string.IsNullOrWhiteSpace(password);

            if (passwordIndicada)
            {
                Validador.ValidarPassword(password);
            }

            var usuario = new Usuario
            {
                Username = string.IsNullOrWhiteSpace(username) ? dni : username.Trim(),
                Email = email?.Trim() ?? string.Empty,
                FechaCreacion = DateTime.Now,
                Activo = true,
                Rol = rol
            };

            usuario.Validar();
            usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordIndicada ? password! : dni);

            return usuario;
        }

        // Solo cambia los datos que vienen cargados
        public static void Actualizar(Usuario usuario, string? username, string? email, string? password)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                usuario.Username = username.Trim();
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                usuario.Email = email.Trim();
            }

            usuario.Validar();

            if (!string.IsNullOrWhiteSpace(password))
            {
                Validador.ValidarPassword(password);
                usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            }
        }

        public static async Task VerificarDisponibleAsync(IUsuarioRepository usuarioRepository, Usuario usuario)
        {
            int? exceptoId = usuario.UsuarioId == 0 ? null : usuario.UsuarioId;

            if (await usuarioRepository.ExisteUsernameAsync(usuario.Username, exceptoId))
            {
                throw new ReglaNegocioException($"El nombre de usuario '{usuario.Username}' ya está en uso.");
            }

            if (await usuarioRepository.ExisteEmailAsync(usuario.Email, exceptoId))
            {
                throw new ReglaNegocioException($"El email '{usuario.Email}' ya está registrado por otro usuario.");
            }
        }
    }
}
