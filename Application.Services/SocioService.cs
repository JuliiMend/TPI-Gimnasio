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
    public class SocioService : ISocioService
    {
        private readonly ISocioRepository _socioRepository;

        public SocioService(ISocioRepository socioRepository)
        {
            _socioRepository = socioRepository;
        }

        public async Task<List<SocioMostrarDTO>> ObtenerTodosAsync(SocioCriteriaDTO criterios)
        {
            var criteria = new SocioCriteria
            {
                Nombre = criterios.Nombre,
                Apellido = criterios.Apellido,
                Dni = criterios.Dni,
                IdPlan = criterios.IdPlan
            };

            var socios = await _socioRepository.ObtenerTodosAsync(criteria);

            return socios.Select(s => new SocioMostrarDTO
            {
                IdPersona = s.PersonaId,
                Dni = s.Dni,
                Nombre = s.Nombre,
                Apellido = s.Apellido,
                FechaAlta = s.FechaAlta,
                NombrePlan = s.Plan?.Nombre ?? "",
                Telefono = s.Telefono,
                FechaNac = s.FechaNac,
                FechaBaja = s.FechaBaja,
                IdPlan = s.IdPlan,
                Email = s.Usuario?.Email ?? "",
                Username = s.Usuario?.Username ?? ""
            }).ToList();
        }

        public async Task<SocioMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var socio = await _socioRepository.ObtenerPorIdAsync(id);

            if (socio == null)
            {
                return null;
            }

            return new SocioMostrarDTO
            {
                IdPersona = socio.PersonaId,
                Dni = socio.Dni,
                Nombre = socio.Nombre,
                Apellido = socio.Apellido,
                FechaAlta = socio.FechaAlta,
                NombrePlan = socio.Plan?.Nombre ?? "",
                Telefono = socio.Telefono,
                FechaNac = socio.FechaNac,
                FechaBaja = socio.FechaBaja,
                IdPlan = socio.IdPlan
            };
        }

        public async Task<int> AgregarAsync(SocioCreaActualizaDTO dto)
        {
            var nuevoUsuario = new Usuario
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = dto.Password, // cuando se hashee se va a llamar passwordhash
                FechaCreacion = DateTime.Now,
                Activo = true,
                Rol = "Socio"
            };

            var socio = new Socio
            {
                Dni = dto.Dni,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                FechaNac = dto.FechaNac,
                FechaAlta = dto.FechaAlta,
                FechaBaja = dto.FechaBaja,
                IdPlan = dto.IdPlan,
                Usuario = nuevoUsuario 
            };

            await _socioRepository.AgregarAsync(socio);

            return socio.PersonaId;
        }

        public async Task ActualizarAsync(int id, SocioCreaActualizaDTO socioDto)
        {
            var socio = new Socio
            {
                PersonaId = id,
                Dni = socioDto.Dni,
                Nombre = socioDto.Nombre,
                Apellido = socioDto.Apellido,
                Telefono = socioDto.Telefono,
                FechaNac = socioDto.FechaNac,
                FechaAlta = socioDto.FechaAlta,
                FechaBaja = socioDto.FechaBaja,
                IdPlan = socioDto.IdPlan
            };

            await _socioRepository.ActualizarAsync(socio);
        }

        public async Task EliminarAsync(int id)
        {
            await _socioRepository.EliminarAsync(id);
        }
    }
}