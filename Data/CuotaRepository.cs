using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Data
{
    public class CuotaRepository : ICuotaRepository
    {
        private readonly GimnasioContext _context;

        public CuotaRepository(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<List<Cuota>> ObtenerTodosAsync()
        {
            return await _context.Cuotas
                .Include(c => c.Socio)
                .Include(c => c.Detalles)
                .ToListAsync();
        }

        public async Task<Cuota?> ObtenerPorIdAsync(int id)
        {
            return await _context.Cuotas
                .Include(c => c.Socio)
                .Include(c => c.Detalles)
                .FirstOrDefaultAsync(c => c.CuotaId == id);
        }

        public async Task AgregarAsync(Cuota cuota)
        {
            await _context.Cuotas.AddAsync(cuota);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Cuota cuota)
        {
            var cuotaExistente = await _context.Cuotas
                .Include(c => c.Detalles)
                .FirstOrDefaultAsync(c => c.CuotaId == cuota.CuotaId);

            if (cuotaExistente != null)
            {
                _context.DetallesCuota.RemoveRange(cuotaExistente.Detalles);

                cuotaExistente.SocioId = cuota.SocioId;
                cuotaExistente.MesAnio = cuota.MesAnio;
                cuotaExistente.FechaPago = cuota.FechaPago;
                cuotaExistente.Valor = cuota.Valor;
                cuotaExistente.Detalles = cuota.Detalles;

                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarAsync(int id)
        {
            var cuota = await _context.Cuotas
                .FirstOrDefaultAsync(c => c.CuotaId == id);

            if (cuota != null)
            {
                _context.Cuotas.Remove(cuota);
                await _context.SaveChangesAsync();
            }
        }
    }
}
