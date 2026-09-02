using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class PlanRepository : IPlanRepository
    {
        private readonly GimnasioContext _context;

        public PlanRepository(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<List<Plan>> ObtenerTodosAsync()
        {
            return await _context.Planes.ToListAsync();
        }

        public async Task<Plan?> ObtenerPorIdAsync(int id)
        {
            return await _context.Planes
                .FirstOrDefaultAsync(p => p.IdPlan == id);
        }
    }
}