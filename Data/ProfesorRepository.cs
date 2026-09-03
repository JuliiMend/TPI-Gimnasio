using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly GimnasioContext _context;

        public ProfesorRepository(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<List<Profesor>> ObtenerTodosAsync()
        {
            return await _context.Profesores.ToListAsync();
        }

        public async Task<Profesor?> ObtenerPorIdAsync(int id)
        {
            return await _context.Profesores
                .FirstOrDefaultAsync(p => p.IdPersona == id);
        }

        public async Task AgregarAsync(Profesor profesor)
        {
            await _context.Profesores.AddAsync(profesor);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Profesor profesor)
        {
            _context.Profesores.Update(profesor);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            Profesor? profesor = await _context.Profesores
                .FirstOrDefaultAsync(p => p.IdPersona == id);

            if (profesor != null)
            {
                _context.Profesores.Remove(profesor);
                await _context.SaveChangesAsync();
            }
        }
    }
}