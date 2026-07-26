using Application.Services;
using Data;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public List<PlanDTO> ObtenerTodos()
        {
            return _planRepository.ObtenerTodos()
                .Select(p => new PlanDTO
                {
                    IdPlan = p.IdPlan,
                    Nombre = p.Nombre,
                    Tipo = p.Tipo,
                    Precio = p.Precio
                }).ToList();
        }

        public PlanDTO? ObtenerPorId(int id)
        {
            var plan = _planRepository.ObtenerPorId(id);
            if (plan == null)
            {
                return null;
            }
            return new PlanDTO
            {
                IdPlan = plan.IdPlan,
                Nombre = plan.Nombre,
                Tipo = plan.Tipo,
                Precio = plan.Precio
            };
        }
    }
}