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

            return usuarios.Select(MapearAMostrar).ToList();
        }

        public async Task<PaginaDTO<UsuarioMostrarDTO>> ObtenerPaginadoAsync(int numeroPagina, int tamanioPagina)
        {
            var pagina = await _usuarioRepository.ObtenerPaginadoAsync(numeroPagina, tamanioPagina);

            return pagina.ADto(MapearAMostrar);
        }

        private static UsuarioMostrarDTO MapearAMostrar(Usuario u)
        {
            return new UsuarioMostrarDTO
            {
                UsuarioId = u.UsuarioId,
                Username = u.Username,
                Email = u.Email,
                Rol = u.Rol
            };
        }

        public async Task<UsuarioMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);

            return usuario == null ? null : MapearAMostrar(usuario);
        }

        public async Task<int> AgregarAsync(UsuarioCreaActualizaDTO dto)
        {
            Validador.ValidarPassword(dto.Password);

            var usuario = new Usuario
            {
                Username = dto.Username?.Trim() ?? string.Empty,
                Email = dto.Email?.Trim() ?? string.Empty,
                FechaCreacion = DateTime.Now,
                Activo = true,
                Rol = Roles.Admin
            };

            usuario.Validar();
            await CuentaUsuario.VerificarDisponibleAsync(_usuarioRepository, usuario);

            usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _usuarioRepository.AgregarAsync(usuario);

            return usuario.UsuarioId;
        }

        public async Task ActualizarAsync(
            int id,
            UsuarioCreaActualizaDTO dto)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id)
                ?? throw new ReglaNegocioException("El usuario no existe.");

            CuentaUsuario.Actualizar(usuario, dto.Username, dto.Email, dto.Password);
            await CuentaUsuario.VerificarDisponibleAsync(_usuarioRepository, usuario);

            await _usuarioRepository.ActualizarAsync(usuario);
        }

        public async Task EliminarAsync(int id, int? idUsuarioActual)
        {
            if (id == idUsuarioActual)
            {
                throw new ReglaNegocioException("No podés eliminar el usuario con el que iniciaste sesión.");
            }

            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);

            if (usuario == null)
            {
                return;
            }

            if (usuario.Rol == Roles.Admin && usuario.Activo &&
                await _usuarioRepository.ContarAdministradoresActivosAsync() <= 1)
            {
                throw new ReglaNegocioException("No se puede eliminar el último administrador del sistema.");
            }

            await _usuarioRepository.EliminarAsync(id);
        }
    }
}