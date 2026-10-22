using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class InscripcionRepository : IInscripcionRepository
    {
        private readonly GimnasioContext _context;

        public InscripcionRepository(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<List<Inscripcion>> ObtenerTodosAsync(int? idClase)
        {
            var query = _context.Inscripciones
                .Include(i => i.Socio)
                .Include(i => i.Clase).ThenInclude(c => c!.Actividad)
                .Include(i => i.Clase).ThenInclude(c => c!.Turno)
                .AsQueryable();

            if (idClase.HasValue && idClase.Value > 0)
            {
                query = query.Where(i => i.IdClase == idClase.Value);
            }

            return await query
                .OrderByDescending(i => i.FechaInscripcion)
                .ToListAsync();
        }

        public async Task<Inscripcion?> ObtenerPorIdAsync(int id)
        {
            return await _context.Inscripciones
                .Include(i => i.Socio)
                .Include(i => i.Clase).ThenInclude(c => c!.Actividad)
                .Include(i => i.Clase).ThenInclude(c => c!.Turno)
                .FirstOrDefaultAsync(i => i.IdInscripcion == id);
        }

        public async Task<int> ContarPorClaseAsync(int idClase)
        {
            return await _context.Inscripciones.CountAsync(i => i.IdClase == idClase);
        }

        public async Task<bool> ExisteAsync(int idSocio, int idClase)
        {
            return await _context.Inscripciones.AnyAsync(i => i.IdSocio == idSocio && i.IdClase == idClase);
        }

        public async Task AgregarAsync(Inscripcion inscripcion)
        {
            await _context.Inscripciones.AddAsync(inscripcion);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var inscripcion = await _context.Inscripciones.FindAsync(id);
            if (inscripcion != null)
            {
                _context.Inscripciones.Remove(inscripcion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
