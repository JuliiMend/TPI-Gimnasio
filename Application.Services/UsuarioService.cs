using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                Username = u.Username,
                Email = u.Email,
                Rol = u.Rol
            }).ToList();
        }

        public async Task<UsuarioMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);

            if (usuario == null)
            {
                return null;
            }

            return new UsuarioMostrarDTO
            {
                UsuarioId = usuario.UsuarioId,
                Username = usuario.Username,
                Email = usuario.Email,
                Rol = usuario.Rol
            };
        }

        public async Task<int> AgregarAsync(UsuarioCreaActualizaDTO dto)
        {
            var usuario = new Usuario
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                FechaCreacion = DateTime.Now,
                Activo = true,
                Rol = "Administrativo"
            };

            await _usuarioRepository.AgregarAsync(usuario);

            return usuario.UsuarioId;
        }

        public async Task ActualizarAsync(
            int id,
            UsuarioCreaActualizaDTO dto)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);

            if (usuario != null)
            {
                usuario.Username = dto.Username;
                usuario.Email = dto.Email;

                if (!string.IsNullOrWhiteSpace(dto.Password))
                {
                    usuario.PasswordHash =
                        BCrypt.Net.BCrypt.HashPassword(dto.Password);
                }

                await _usuarioRepository.ActualizarAsync(usuario);
            }
        }

        public async Task EliminarAsync(int id)
        {
            await _usuarioRepository.EliminarAsync(id);
        }
    }
}