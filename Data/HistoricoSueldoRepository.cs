using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class HistoricoSueldoRepository : IHistoricoSueldoRepository
    {
        private readonly GimnasioContext _context;

        public HistoricoSueldoRepository(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<List<HistoricoSueldo>> ObtenerTodosAsync(int? idProfesor)
        {
            var query = _context.HistoricoSueldos
                .Include(h => h.Profesor)
                .AsQueryable();

            if (idProfesor.HasValue && idProfesor.Value > 0)
            {
                query = query.Where(h => h.IdProfesor == idProfesor.Value);
            }

            return await query
                .OrderBy(h => h.IdProfesor)
                .ThenBy(h => h.FechaDesde)
                .ToListAsync();
        }

        public async Task<HistoricoSueldo?> ObtenerPorIdAsync(int id)
        {
            return await _context.HistoricoSueldos
                .Include(h => h.Profesor)
                .FirstOrDefaultAsync(h => h.IdHistoricoSueldo == id);
        }

        public async Task<bool> ExisteAsync(int idProfesor, DateTime fechaDesde)
        {
            return await _context.HistoricoSueldos
                .AnyAsync(h => h.IdProfesor == idProfesor && h.FechaDesde == fechaDesde.Date);
        }

        public async Task AgregarAsync(HistoricoSueldo historicoSueldo)
        {
            await _context.HistoricoSueldos.AddAsync(historicoSueldo);
            await _context.SaveChangesAsync();
        }
    }
}
