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

        public async Task ActualizarAsync(Cuota cuotaModificada)
        {
            var cuotaExistente = await _context.Cuotas
                .Include(c => c.Detalles)
                .FirstOrDefaultAsync(c => c.CuotaId == cuotaModificada.CuotaId);

            if (cuotaExistente != null)
            {
                cuotaExistente.SocioId = cuotaModificada.SocioId;
                cuotaExistente.MesAnio = cuotaModificada.MesAnio;
                cuotaExistente.FechaPago = cuotaModificada.FechaPago;
                cuotaExistente.Valor = cuotaModificada.Valor;

                var idsModificados = cuotaModificada.Detalles.Select(d => d.DetalleCuotaId).ToList();
                var aEliminar = cuotaExistente.Detalles
                    .Where(d => d.DetalleCuotaId != 0 && !idsModificados.Contains(d.DetalleCuotaId))
                    .ToList();

                foreach (var det in aEliminar)
                {
                    _context.DetallesCuota.Remove(det);
                }

                foreach (var detModificado in cuotaModificada.Detalles)
                {
                    var existente = cuotaExistente.Detalles.FirstOrDefault(d => d.DetalleCuotaId == detModificado.DetalleCuotaId && d.DetalleCuotaId != 0);

                    if (existente != null)
                    {
                        existente.Concepto = detModificado.Concepto;
                        existente.Subtotal = detModificado.Subtotal;
                        existente.Monto = detModificado.Monto;
                    }
                    else
                    {
                        cuotaExistente.Detalles.Add(new DetalleCuota
                        {
                            Concepto = detModificado.Concepto,
                            Subtotal = detModificado.Subtotal,
                            Monto = detModificado.Monto
                        });
                    }
                }

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