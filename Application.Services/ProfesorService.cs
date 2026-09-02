using Application.Services;
using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly IProfesorRepository _profesorRepository;

        public ProfesorService(IProfesorRepository profesorRepository)
        {
            _profesorRepository = profesorRepository;
        }

        public async Task<List<ProfesorDTO>> ObtenerTodosAsync()
        {
            var profesores = await _profesorRepository.ObtenerTodosAsync();

            return profesores.Select(p => new ProfesorDTO
            {
                IdPersona = p.IdPersona,
                Dni = p.Dni,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Email = p.Email,
                Cargo = p.Cargo
            }).ToList();
        }

        public async Task<ProfesorDTO?> ObtenerPorIdAsync(int id)
        {
            var profesor = await _profesorRepository.ObtenerPorIdAsync(id);

            if (profesor == null)
            {
                return null;
            }

            return new ProfesorDTO
            {
                IdPersona = profesor.IdPersona,
                Dni = profesor.Dni,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Email = profesor.Email,
                Cargo = profesor.Cargo
            };
        }

        public async Task AgregarAsync(ProfesorCreaActualizaDTO profesorDto)
        {
            var profesor = new Profesor
            {
                Dni = profesorDto.Dni,
                Nombre = profesorDto.Nombre,
                Apellido = profesorDto.Apellido,
                Email = profesorDto.Email,
                Telefono = profesorDto.Telefono,
                FechaNac = profesorDto.FechaNac,
                Cargo = profesorDto.Cargo
            };

            await _profesorRepository.AgregarAsync(profesor);
        }

        public async Task ActualizarAsync(int id, ProfesorCreaActualizaDTO profesorDto)
        {
            var profesor = new Profesor
            {
                IdPersona = id,
                Dni = profesorDto.Dni,
                Nombre = profesorDto.Nombre,
                Apellido = profesorDto.Apellido,
                Email = profesorDto.Email,
                Telefono = profesorDto.Telefono,
                FechaNac = profesorDto.FechaNac,
                Cargo = profesorDto.Cargo
            };

            await _profesorRepository.ActualizarAsync(profesor);
        }

        public async Task EliminarAsync(int id)
        {
            await _profesorRepository.EliminarAsync(id);
        }
    }
}