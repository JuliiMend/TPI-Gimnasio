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

        public ProfesorService(IProfesorRepository profesorRepository)
        {
            _profesorRepository = profesorRepository;
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

        public async Task AgregarAsync(ProfesorCreaActualizaDTO profesorDto)
        {
            var username = !string.IsNullOrWhiteSpace(profesorDto.Username)
                ? profesorDto.Username.Trim()
                : (!string.IsNullOrWhiteSpace(profesorDto.Dni) ? profesorDto.Dni.Trim() : $"prof_{Guid.NewGuid().ToString("N")[..8]}");

            var password = !string.IsNullOrWhiteSpace(profesorDto.Password)
                ? profesorDto.Password
                : (!string.IsNullOrWhiteSpace(profesorDto.Dni) ? profesorDto.Dni.Trim() : "123456");

            var nuevoUsuario = new Usuario
            {
                Username = username,
                Email = profesorDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                FechaCreacion = DateTime.Now,
                Activo = true,
                Rol = "Profesor"
            };

            var profesor = new Profesor
            {
                Dni = profesorDto.Dni,
                Nombre = profesorDto.Nombre,
                Apellido = profesorDto.Apellido,
                Telefono = profesorDto.Telefono,
                FechaNac = profesorDto.FechaNac,
                Cargo = profesorDto.Cargo,
                Usuario = nuevoUsuario
            };

            await _profesorRepository.AgregarAsync(profesor);
        }

        public async Task ActualizarAsync(int id, ProfesorCreaActualizaDTO profesorDto)
        {
            var profesor = await _profesorRepository.ObtenerPorIdAsync(id);

            if (profesor != null)
            {
                profesor.Dni = profesorDto.Dni;
                profesor.Nombre = profesorDto.Nombre;
                profesor.Apellido = profesorDto.Apellido;
                profesor.Telefono = profesorDto.Telefono;
                profesor.FechaNac = profesorDto.FechaNac;
                profesor.Cargo = profesorDto.Cargo;

                if (profesor.Usuario != null)
                {
                    if (!string.IsNullOrWhiteSpace(profesorDto.Email))
                    {
                        profesor.Usuario.Email = profesorDto.Email;
                    }
                    if (!string.IsNullOrWhiteSpace(profesorDto.Password))
                    {
                        profesor.Usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(profesorDto.Password);
                    }
                }

                await _profesorRepository.ActualizarAsync(profesor);
            }
        }

        public async Task EliminarAsync(int id)
        {
            await _profesorRepository.EliminarAsync(id);
        }
    }
}