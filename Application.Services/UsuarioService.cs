using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain.Model;
using DTOs;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<UsuarioMostrarDTO>> ObtenerTodosAsync()
        {
            var usuarios = await _usuarioRepository.ObtenerTodosAsync();

            return usuarios.Select(u => new UsuarioMostrarDTO
            {
                UsuarioId = u.UsuarioId,
                Username = u.Username
            }).ToList();
        }

        public async Task<UsuarioMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);
            if (usuario == null) return null;

            return new UsuarioMostrarDTO
            {
                UsuarioId = usuario.UsuarioId,
                Username = usuario.Username
            };
        }

        public async Task<int> AgregarAsync(UsuarioCreaActualizaDTO dto)
        {
            var usuario = new Usuario
            {
                Username = dto.Username,
                Email = dto.Email, 
                PasswordHash = dto.Password, // agregar hasheo acaaaaaaaaaaaa
                FechaCreacion = DateTime.Now, 
                Activo = true,
                Rol = "Usuario" 
            };

            await _usuarioRepository.AgregarAsync(usuario);
            return usuario.UsuarioId; 
        }

        public async Task ActualizarAsync(int id, UsuarioCreaActualizaDTO dto)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);

            if (usuario != null)
            {
                usuario.Username = dto.Username;
                usuario.PasswordHash = dto.Password;

                await _usuarioRepository.ActualizarAsync(usuario);
            }
        }

        public async Task EliminarAsync(int id)
        {
            await _usuarioRepository.EliminarAsync(id);
        }
    }
}