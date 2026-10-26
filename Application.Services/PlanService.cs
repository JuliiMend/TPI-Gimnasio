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
                Nombre = planDto.Nombre?.Trim() ?? string.Empty,
                Tipo = planDto.Tipo?.Trim() ?? string.Empty,
                Precio = planDto.Precio,
                Descripcion = planDto.Descripcion?.Trim() ?? string.Empty
            };

            planNuevo.Validar();
            planNuevo.Actividades = await ObtenerActividadesAsync(planDto.IdsActividades);

            await _planRepository.AgregarAsync(planNuevo);
            return planNuevo.PlanId;
        }

        public async Task ActualizarAsync(int id, PlanCreaActualizaDTO planDto)
        {
            var planExistente = await _planRepository.ObtenerPorIdAsync(id)
                ?? throw new ReglaNegocioException($"El plan con ID {id} no existe.");

            planExistente.Nombre = planDto.Nombre?.Trim() ?? string.Empty;
            planExistente.Tipo = planDto.Tipo?.Trim() ?? string.Empty;
            planExistente.Precio = planDto.Precio;
            planExistente.Descripcion = planDto.Descripcion?.Trim() ?? string.Empty;

            planExistente.Validar();

            var actividades = await ObtenerActividadesAsync(planDto.IdsActividades);
            planExistente.Actividades.Clear();
            planExistente.Actividades.AddRange(actividades);

            await _planRepository.ActualizarAsync(planExistente);
        }

        private async Task<List<Actividad>> ObtenerActividadesAsync(List<int>? idsActividades)
        {
            var ids = (idsActividades ?? new List<int>()).Distinct().ToList();

            if (ids.Count == 0)
            {
                throw new ReglaNegocioException("El plan debe incluir al menos una actividad.");
            }

            var actividades = await _actividadRepository.ObtenerPorIdsAsync(ids);

            if (actividades.Count != ids.Count)
            {
                throw new ReglaNegocioException("Alguna de las actividades seleccionadas no existe.");
            }

            return actividades;
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