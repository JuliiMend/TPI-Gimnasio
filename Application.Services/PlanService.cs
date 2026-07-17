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
            throw new NotImplementedException();
        }

        public PlanDTO? ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}