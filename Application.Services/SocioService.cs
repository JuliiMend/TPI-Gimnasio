using Application.Services;
using Data;
using Domain.Model;
using DTOs;
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
                Email = s.Email,
                FechaAlta = s.FechaAlta,
                NombrePlan = s.Plan?.Nombre ?? ""
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
                Email = socio.Email,
                FechaAlta = socio.FechaAlta,
                NombrePlan = socio.Plan?.Nombre ?? ""
            };
        }

        public async Task AgregarAsync(SocioCreaActualizaDTO socioDto)
        {
            var socio = new Socio
            {
                Dni = socioDto.Dni,
                Nombre = socioDto.Nombre,
                Apellido = socioDto.Apellido,
                Email = socioDto.Email,
                Telefono = socioDto.Telefono,
                FechaNac = socioDto.FechaNac,
                FechaAlta = socioDto.FechaAlta,
                FechaBaja = socioDto.FechaBaja,
                IdPlan = socioDto.IdPlan
            };

            await _socioRepository.AgregarAsync(socio);
        }

        public async Task ActualizarAsync(int id, SocioCreaActualizaDTO socioDto)
        {
            var socio = new Socio
            {
                PersonaId = id, 
                Dni = socioDto.Dni,
                Nombre = socioDto.Nombre,
                Apellido = socioDto.Apellido,
                Email = socioDto.Email,
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