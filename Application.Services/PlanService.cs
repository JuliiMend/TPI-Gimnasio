using Data;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;

namespace Application.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IActividadRepository _actividadRepository;

        public PlanService(IPlanRepository planRepository, IActividadRepository actividadRepository)
        {
            _planRepository = planRepository;
            _actividadRepository = actividadRepository;
        }

        public async Task<List<PlanMostrarDTO>> ObtenerTodosAsync()
        {
            var planes = await _planRepository.ObtenerTodosAsync();

            return planes.Select(MapearAMostrar).ToList();
        }

        public async Task<PlanMostrarDTO?> ObtenerPorIdAsync(int id)
        {
            var plan = await _planRepository.ObtenerPorIdAsync(id);

            if (plan == null)
            {
                return null;
            }

            return MapearAMostrar(plan);
        }

        public async Task<int> CrearAsync(PlanCreaActualizaDTO planDto)
        {
            var planNuevo = new Plan
            {
                Nombre = planDto.Nombre,
                Tipo = planDto.Tipo,
                Precio = planDto.Precio,
                Descripcion = planDto.Descripcion,
                Actividades = await _actividadRepository.ObtenerPorIdsAsync(planDto.IdsActividades)
            };

            await _planRepository.AgregarAsync(planNuevo);
            return planNuevo.PlanId;
        }

        public async Task ActualizarAsync(int id, PlanCreaActualizaDTO planDto)
        {
            var planExistente = await _planRepository.ObtenerPorIdAsync(id);

            if (planExistente != null)
            {
                planExistente.Nombre = planDto.Nombre;
                planExistente.Tipo = planDto.Tipo;
                planExistente.Precio = planDto.Precio;
                planExistente.Descripcion = planDto.Descripcion;

                var actividades = await _actividadRepository.ObtenerPorIdsAsync(planDto.IdsActividades);
                planExistente.Actividades.Clear();
                planExistente.Actividades.AddRange(actividades);

                await _planRepository.ActualizarAsync(planExistente);
            }
            else
            {
                throw new Exception($"El plan con ID {id} no existe en la base de datos.");
            }
        }

        public async Task EliminarAsync(int id)
        {
            await _planRepository.EliminarAsync(id);
        }

        private static PlanMostrarDTO MapearAMostrar(Plan p)
        {
            return new PlanMostrarDTO
            {
                IdPlan = p.PlanId,
                Nombre = p.Nombre,
                Tipo = p.Tipo,
                Precio = p.Precio,
                Descripcion = p.Descripcion ?? string.Empty,
                Actividades = string.Join(", ", p.Actividades.Select(a => a.Tipo)),
                IdsActividades = p.Actividades.Select(a => a.IdActividad).ToList()
            };
        }
    }
}