using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class MantenimientoRepository : IMantenimientoRepository
    {
        private readonly GimnasioContext _context;

        public MantenimientoRepository(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<List<Mantenimiento>> ObtenerTodosAsync(int? idMaquina)
        {
            var query = _context.Mantenimientos
                .Include(m => m.Maquina)
                .AsQueryable();

            if (idMaquina.HasValue && idMaquina.Value > 0)
            {
                query = query.Where(m => m.IdMaquina == idMaquina.Value);
            }

            return await query
                .OrderByDescending(m => m.FechaInicio)
                .ToListAsync();
        }

        public async Task<Mantenimiento?> ObtenerPorIdAsync(int id)
        {
            return await _context.Mantenimientos
                .Include(m => m.Maquina)
                .FirstOrDefaultAsync(m => m.IdMantenimiento == id);
        }

        public async Task AgregarAsync(Mantenimiento mantenimiento)
        {
            await _context.Mantenimientos.AddAsync(mantenimiento);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Mantenimiento mantenimiento)
        {
            // Si viene del mismo contexto ya está trackeado y EF detecta solo los cambios
            if (_context.Entry(mantenimiento).State == EntityState.Detached)
            {
                _context.Mantenimientos.Update(mantenimiento);
            }

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            if (mantenimiento != null)
            {
                _context.Mantenimientos.Remove(mantenimiento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
