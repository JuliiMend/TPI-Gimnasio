using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly GimnasioContext _context;

        public ActividadRepository(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<List<Actividad>> ObtenerTodosAsync()
        {
            return await _context.Actividades.ToListAsync();
        }

        public async Task<List<Actividad>> ObtenerPorIdsAsync(IEnumerable<int> ids)
        {
            var lista = ids.Distinct().ToList();

            return await _context.Actividades
                .Where(a => lista.Contains(a.IdActividad))
                .ToListAsync();
        }

        public async Task<Actividad?> ObtenerPorIdAsync(int id)
        {
            return await _context.Actividades
                .FirstOrDefaultAsync(a => a.IdActividad == id);
        }

        public async Task AgregarAsync(Actividad actividad)
        {
            await _context.Actividades.AddAsync(actividad);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Actividad actividad)
        {
            _context.Actividades.Update(actividad);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad != null)
            {
                _context.Actividades.Remove(actividad);
                await _context.SaveChangesAsync();
            }
        }
    }
}
