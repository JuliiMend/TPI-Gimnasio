using Data;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}