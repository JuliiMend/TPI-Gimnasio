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

        public PlanService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<List<PlanDTO>> ObtenerTodosAsync()
        {
            var planes = await _planRepository.ObtenerTodosAsync();

            return planes.Select(p => new PlanDTO
            {
                IdPlan = p.PlanId,
                Nombre = p.Nombre,
                Tipo = p.Tipo,
                Precio = p.Precio
            }).ToList();
        }

        public async Task<PlanDTO?> ObtenerPorIdAsync(int id)
        {
            var plan = await _planRepository.ObtenerPorIdAsync(id);

            if (plan == null)
            {
                return null;
            }

            return new PlanDTO
            {
                IdPlan = plan.PlanId,
                Nombre = plan.Nombre,
                Tipo = plan.Tipo,
                Precio = plan.Precio
            };
        }

        public async Task CrearAsync(PlanCreaActualizaDTO planDto)
        {
            var planNuevo = new Plan
            {
                Nombre = planDto.Nombre,
                Tipo = planDto.Tipo,
                Precio = planDto.Precio,
                Descripcion = planDto.Descripcion
            };

            await _planRepository.AgregarAsync(planNuevo);
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

                await _planRepository.ActualizarAsync(planExistente);
            }
            else
            {
                throw new Exception($"El plan con ID {id} no existe en la base de datos.");
            }
        }
    }
}