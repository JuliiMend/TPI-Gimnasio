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

        public List<ProfesorDTO> ObtenerTodos()
        {
            return _profesorRepository.ObtenerTodos()
                .Select(p => new ProfesorDTO
                {
                    IdPersona = p.PersonaId,
                    Dni = p.Dni,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Email = p.Email,
                    Cargo = p.Cargo
                }).ToList();
        }

        public ProfesorDTO? ObtenerPorId(int id)
        {
            var profesor = _profesorRepository.ObtenerPorId(id);
            if (profesor == null)
            {
                return null;
            }
            return new ProfesorDTO
            {
                IdPersona = profesor.PersonaId,
                Dni = profesor.Dni,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Email = profesor.Email,
                Cargo = profesor.Cargo
            };
        }

        public void Agregar(ProfesorCreaActualizaDTO profesorDto)
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
            _profesorRepository.Agregar(profesor);
        }

        public void Actualizar(int id, ProfesorCreaActualizaDTO profesorDto)
        {
            var profesor = new Profesor
            {
                PersonaId = id, 
                Dni = profesorDto.Dni,
                Nombre = profesorDto.Nombre,
                Apellido = profesorDto.Apellido,
                Email = profesorDto.Email,
                Telefono = profesorDto.Telefono,
                FechaNac = profesorDto.FechaNac,
                Cargo = profesorDto.Cargo
            };
            _profesorRepository.Actualizar(profesor);
        }

        public void Eliminar(int id)
        {
            _profesorRepository.Eliminar(id);
        }
    }
}