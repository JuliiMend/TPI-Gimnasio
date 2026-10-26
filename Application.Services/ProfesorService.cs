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
    public class ProfesorService : IProfesorService
    {
        private readonly IProfesorRepository _profesorRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ProfesorService(IProfesorRepository profesorRepository, IUsuarioRepository usuarioRepository)
        {
            _profesorRepository = profesorRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<ProfesorMostrarDTO>> ObtenerTodosAsync()
        {
            var profesores = await _profesorRepository.ObtenerTodosAsync();

            return profesores.Select(p => new ProfesorMostrarDTO
            {
                IdPersona = p.PersonaId,
                Dni = p.Dni,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Telefono = p.Telefono,
                FechaNac = p.FechaNac,
                Cargo = p.Cargo,
                Email = p.Usuario?.Email ?? "Sin email",
                Username = p.Usuario?.Username ?? "Sin usuario",
                UsuarioActivo = p.Usuario?.Activo ?? false
            }).ToList();
        }

        public async Task<ProfesorMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var profesor = await _profesorRepository.ObtenerPorIdAsync(id);

            if (profesor == null)
            {
                return null;
            }

            return new ProfesorMostrarDTO
            {
                IdPersona = profesor.PersonaId,
                Dni = profesor.Dni,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Telefono = profesor.Telefono,
                FechaNac = profesor.FechaNac,
                Cargo = profesor.Cargo,
                Email = profesor.Usuario?.Email ?? "Sin email",
                Username = profesor.Usuario?.Username ?? "Sin usuario",
                UsuarioActivo = profesor.Usuario?.Activo ?? false
            };
        }

        public async Task<ProfesorMostrarDTO?> ObtenerPorUsuarioAsync(int usuarioId)
        {
            var profesor = await _profesorRepository.ObtenerPorUsuarioIdAsync(usuarioId);

            return profesor == null ? null : await ObtenerPorIdAsync(profesor.PersonaId);
        }

        public async Task<int> AgregarAsync(ProfesorCreaActualizaDTO profesorDto)
        {
            var profesor = new Profesor
            {
                Dni = profesorDto.Dni?.Trim() ?? string.Empty,
                Nombre = profesorDto.Nombre?.Trim() ?? string.Empty,
                Apellido = profesorDto.Apellido?.Trim() ?? string.Empty,
                Telefono = profesorDto.Telefono?.Trim() ?? string.Empty,
                FechaNac = profesorDto.FechaNac.Date,
                Cargo = profesorDto.Cargo?.Trim() ?? string.Empty
            };

            profesor.Validar();
            profesor.Usuario = CuentaUsuario.Crear(profesor.Dni, profesorDto.Username, profesorDto.Email, profesorDto.Password, Roles.Profesor);

            await VerificarDuplicadosAsync(profesor);

            await _profesorRepository.AgregarAsync(profesor);
            return profesor.PersonaId;
        }

        public async Task ActualizarAsync(int id, ProfesorCreaActualizaDTO profesorDto)
        {
            var profesor = await _profesorRepository.ObtenerPorIdAsync(id)
                ?? throw new ReglaNegocioException("El profesor no existe.");

            profesor.Dni = profesorDto.Dni?.Trim() ?? string.Empty;
            profesor.Nombre = profesorDto.Nombre?.Trim() ?? string.Empty;
            profesor.Apellido = profesorDto.Apellido?.Trim() ?? string.Empty;
            profesor.Telefono = profesorDto.Telefono?.Trim() ?? string.Empty;
            profesor.FechaNac = profesorDto.FechaNac.Date;
            profesor.Cargo = profesorDto.Cargo?.Trim() ?? string.Empty;

            profesor.Validar();

            if (profesor.Usuario != null)
            {
                CuentaUsuario.Actualizar(profesor.Usuario, profesorDto.Username, profesorDto.Email, profesorDto.Password);
            }

            await VerificarDuplicadosAsync(profesor);

            await _profesorRepository.ActualizarAsync(profesor);
        }

        private async Task VerificarDuplicadosAsync(Profesor profesor)
        {
            if (await _profesorRepository.ExisteDniAsync(profesor.Dni, profesor.PersonaId == 0 ? null : profesor.PersonaId))
            {
                throw new ReglaNegocioException($"Ya existe un profesor con el DNI {profesor.Dni}.");
            }

            if (profesor.Usuario != null)
            {
                await CuentaUsuario.VerificarDisponibleAsync(_usuarioRepository, profesor.Usuario);
            }
        }

        public async Task EliminarAsync(int id)
        {
            await _profesorRepository.EliminarAsync(id);
        }
    }
}