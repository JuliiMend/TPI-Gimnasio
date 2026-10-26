using Application.Services;
using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly IAdministradorRepository _administradorRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public AdministradorService(IAdministradorRepository administradorRepository, IUsuarioRepository usuarioRepository)
        {
            _administradorRepository = administradorRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<AdministradorMostrarDTO>> ObtenerTodosAsync()
        {
            var administradores = await _administradorRepository.ObtenerTodosAsync();

            return administradores.Select(p => new AdministradorMostrarDTO
            {
                IdPersona = p.PersonaId,
                Dni = p.Dni,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Telefono = p.Telefono,
                FechaNac = p.FechaNac,
                Email = p.Usuario?.Email ?? "Sin email",
                Username = p.Usuario?.Username ?? "Sin usuario",
                UsuarioActivo = p.Usuario?.Activo ?? false
            }).ToList();
        }

        public async Task<AdministradorMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var administrador = await _administradorRepository.ObtenerPorIdAsync(id);

            if (administrador == null)
            {
                return null;
            }

            return new AdministradorMostrarDTO
            {
                IdPersona = administrador.PersonaId,
                Dni = administrador.Dni,
                Nombre = administrador.Nombre,
                Apellido = administrador.Apellido,
                Telefono = administrador.Telefono,
                FechaNac = administrador.FechaNac,
                Email = administrador.Usuario?.Email ?? "Sin email",
                Username = administrador.Usuario?.Username ?? "Sin usuario",
                UsuarioActivo = administrador.Usuario?.Activo ?? false
            };
        }

        public async Task<int> AgregarAsync(AdministradorCreaActualizaDTO administradorDto)
        {
            var administrador = new Administrador
            {
                Dni = administradorDto.Dni?.Trim() ?? string.Empty,
                Nombre = administradorDto.Nombre?.Trim() ?? string.Empty,
                Apellido = administradorDto.Apellido?.Trim() ?? string.Empty,
                Telefono = administradorDto.Telefono?.Trim() ?? string.Empty,
                FechaNac = administradorDto.FechaNac.Date
            };

            administrador.Validar();
            administrador.Usuario = CuentaUsuario.Crear(administrador.Dni, administradorDto.Username, administradorDto.Email, administradorDto.Password, Roles.Admin);

            await VerificarDuplicadosAsync(administrador);

            await _administradorRepository.AgregarAsync(administrador);
            return administrador.PersonaId;
        }

        public async Task ActualizarAsync(int id, AdministradorCreaActualizaDTO administradorDto)
        {
            var administrador = await _administradorRepository.ObtenerPorIdAsync(id)
                ?? throw new ReglaNegocioException("El administrador no existe.");

            administrador.Dni = administradorDto.Dni?.Trim() ?? string.Empty;
            administrador.Nombre = administradorDto.Nombre?.Trim() ?? string.Empty;
            administrador.Apellido = administradorDto.Apellido?.Trim() ?? string.Empty;
            administrador.Telefono = administradorDto.Telefono?.Trim() ?? string.Empty;
            administrador.FechaNac = administradorDto.FechaNac.Date;

            administrador.Validar();

            if (administrador.Usuario != null)
            {
                CuentaUsuario.Actualizar(administrador.Usuario, administradorDto.Username, administradorDto.Email, administradorDto.Password);
            }

            await VerificarDuplicadosAsync(administrador);

            await _administradorRepository.ActualizarAsync(administrador);
        }

        private async Task VerificarDuplicadosAsync(Administrador administrador)
        {
            if (await _administradorRepository.ExisteDniAsync(administrador.Dni, administrador.PersonaId == 0 ? null : administrador.PersonaId))
            {
                throw new ReglaNegocioException($"Ya existe un administrador con el DNI {administrador.Dni}.");
            }

            if (administrador.Usuario != null)
            {
                await CuentaUsuario.VerificarDisponibleAsync(_usuarioRepository, administrador.Usuario);
            }
        }

        public async Task EliminarAsync(int id, int? idUsuarioActual)
        {
            var administrador = await _administradorRepository.ObtenerPorIdAsync(id);

            if (administrador == null)
            {
                return;
            }

            if (administrador.UsuarioId.HasValue && administrador.UsuarioId == idUsuarioActual)
            {
                throw new ReglaNegocioException("No podés eliminar el administrador con el que iniciaste sesión.");
            }

            if (await _usuarioRepository.ContarAdministradoresActivosAsync() <= 1)
            {
                throw new ReglaNegocioException("No se puede eliminar el último administrador del sistema.");
            }

            await _administradorRepository.EliminarAsync(id);
        }
    }
}
