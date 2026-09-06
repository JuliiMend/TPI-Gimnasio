using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly GimnasioContext _context;

        public TurnoRepository(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<List<Turno>> ObtenerTodosAsync()
        {
            return await _context.Turnos.ToListAsync();
        }

        public async Task<Turno?> ObtenerPorIdAsync(int id)
        {
            return await _context.Turnos
                .FirstOrDefaultAsync(t => t.IdTurno == id);
        }

        public async Task AgregarAsync(Turno turno)
        {
            await _context.Turnos.AddAsync(turno);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Turno turno)
        {
            _context.Turnos.Update(turno);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            Turno? turno = await _context.Turnos
                .FirstOrDefaultAsync(t => t.IdTurno == id);

            if (turno != null)
            {
                _context.Turnos.Remove(turno);
                await _context.SaveChangesAsync();
            }
        }
    }
}