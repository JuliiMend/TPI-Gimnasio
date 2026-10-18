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

        public AdministradorService(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
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
            var username = !string.IsNullOrWhiteSpace(administradorDto.Username)
                ? administradorDto.Username.Trim()
                : (!string.IsNullOrWhiteSpace(administradorDto.Dni) ? administradorDto.Dni.Trim() : $"admin_{Guid.NewGuid().ToString("N")[..8]}");

            var password = !string.IsNullOrWhiteSpace(administradorDto.Password)
                ? administradorDto.Password
                : (!string.IsNullOrWhiteSpace(administradorDto.Dni) ? administradorDto.Dni.Trim() : "123456");

            var nuevoUsuario = new Usuario
            {
                Username = username,
                Email = administradorDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                FechaCreacion = DateTime.Now,
                Activo = true,
                Rol = "Admin"
            };

            var administrador = new Administrador
            {
                Dni = administradorDto.Dni,
                Nombre = administradorDto.Nombre,
                Apellido = administradorDto.Apellido,
                Telefono = administradorDto.Telefono,
                FechaNac = administradorDto.FechaNac,
                Usuario = nuevoUsuario
            };

            await _administradorRepository.AgregarAsync(administrador);
            return administrador.PersonaId;
        }

        public async Task ActualizarAsync(int id, AdministradorCreaActualizaDTO administradorDto)
        {
            var administrador = await _administradorRepository.ObtenerPorIdAsync(id);

            if (administrador != null)
            {
                administrador.Dni = administradorDto.Dni;
                administrador.Nombre = administradorDto.Nombre;
                administrador.Apellido = administradorDto.Apellido;
                administrador.Telefono = administradorDto.Telefono;
                administrador.FechaNac = administradorDto.FechaNac;

                if (administrador.Usuario != null)
                {
                    if (!string.IsNullOrWhiteSpace(administradorDto.Email))
                    {
                        administrador.Usuario.Email = administradorDto.Email;
                    }
                    if (!string.IsNullOrWhiteSpace(administradorDto.Password))
                    {
                        administrador.Usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(administradorDto.Password);
                    }
                }

                await _administradorRepository.ActualizarAsync(administrador);
            }
        }

        public async Task EliminarAsync(int id)
        {
            await _administradorRepository.EliminarAsync(id);
        }
    }
}
