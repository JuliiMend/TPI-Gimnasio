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
                .FirstOrDefaultAsync(p => p.PlanId == id);
        }

        public async Task AgregarAsync(Plan plan)
        {
            await _context.Planes.AddAsync(plan);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Plan plan)
        {
            _context.Planes.Update(plan);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var plan = await _context.Planes.FindAsync(id);
            if (plan != null)
            {
                _context.Planes.Remove(plan);
                await _context.SaveChangesAsync();
            }
        }
    }
}