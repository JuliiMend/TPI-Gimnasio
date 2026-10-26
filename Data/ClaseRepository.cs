using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class ClaseRepository : IClaseRepository
    {
        private readonly GimnasioContext _context;

        public ClaseRepository(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<List<Clase>> ObtenerTodosAsync(int? idProfesor = null)
        {
            var query = _context.Clases
                .Include(c => c.Actividad)
                .Include(c => c.Profesor)
                .Include(c => c.Turno)
                .Include(c => c.Inscripciones)
                .AsQueryable();

            if (idProfesor.HasValue)
            {
                query = query.Where(c => c.IdProfesor == idProfesor.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<Clase?> ObtenerPorIdAsync(int id)
        {
            return await _context.Clases
                .Include(c => c.Actividad)
                .Include(c => c.Profesor)
                .Include(c => c.Turno)
                .Include(c => c.Inscripciones)
                .FirstOrDefaultAsync(c => c.IdClase == id);
        }

        public async Task AgregarAsync(Clase clase)
        {
            await _context.Clases.AddAsync(clase);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Clase clase)
        {
            if (_context.Entry(clase).State == EntityState.Detached)
            {
                _context.Clases.Update(clase);
            }

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var clase = await _context.Clases.FindAsync(id);
            if (clase != null)
            {
                _context.Clases.Remove(clase);
                await _context.SaveChangesAsync();
            }
        }
    }
}
