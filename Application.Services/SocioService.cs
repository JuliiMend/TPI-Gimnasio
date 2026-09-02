using Application.Services;
using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public List<SocioMostrarDTO> ObtenerTodos(SocioCriteriaDTO criterios)
        {
            var criteria = new SocioCriteria
            {
                Nombre = criterios.Nombre,
                Apellido = criterios.Apellido,
                Dni = criterios.Dni,
                IdPlan = criterios.IdPlan
            };

            var socios = _socioRepository.ObtenerTodos(criteria);
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

        public SocioMostrarDTO? ObtenerPorId(int id)
        {
            var socio = _socioRepository.ObtenerPorId(id);
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

        public void Agregar(SocioCreaActualizaDTO socioDto)
        {
            var socio = new Socio
            {
                PersonaId = socioDto.IdPersona,
                Dni = socioDto.Dni,
                Nombre = socioDto.Nombre,
                Apellido = socioDto.Apellido,
                Email = socioDto.Email,
                Telefono = socioDto.Telefono,
                FechaNac = socioDto.FechaNac,
                Usuario = socioDto.Usuario,
                Contraseña = socioDto.Contraseña,
                FechaAlta = socioDto.FechaAlta,
                FechaBaja = socioDto.FechaBaja,
                IdPlan = socioDto.IdPlan
            };
            _socioRepository.Agregar(socio);
        }

        public void Actualizar(int id, SocioCreaActualizaDTO socioDto)
        {
            var socio = new Socio
            {
                PersonaId = socioDto.IdPersona,
                Dni = socioDto.Dni,
                Nombre = socioDto.Nombre,
                Apellido = socioDto.Apellido,
                Email = socioDto.Email,
                Telefono = socioDto.Telefono,
                FechaNac = socioDto.FechaNac,
                Usuario = socioDto.Usuario,
                Contraseña = socioDto.Contraseña,
                FechaAlta = socioDto.FechaAlta,
                FechaBaja = socioDto.FechaBaja,
                IdPlan = socioDto.IdPlan
            };
            _socioRepository.Actualizar(socio);
        }

        public void Eliminar(int id)
        {
            _socioRepository.Eliminar(id);
        }
    }
}