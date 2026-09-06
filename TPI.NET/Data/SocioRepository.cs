using Data;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SocioRepository : ISocioRepository
    {
        private readonly GimnasioContext _context;

        public SocioRepository(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<List<Socio>> ObtenerTodosAsync(SocioCriteria criterios)
        {
            var query = _context.Socios.AsQueryable();

            if (criterios != null)
            {
                if (!string.IsNullOrWhiteSpace(criterios.Nombre))
                {
                    query = query.Where(s => s.Nombre.Contains(criterios.Nombre));
                }

                if (!string.IsNullOrWhiteSpace(criterios.Apellido))
                {
                    query = query.Where(s => s.Apellido.Contains(criterios.Apellido));
                }

                if (!string.IsNullOrWhiteSpace(criterios.Dni))
                {
                    query = query.Where(s => s.Dni.Contains(criterios.Dni));
                }

                if (criterios.IdPlan > 0)
                {
                    query = query.Where(s => s.IdPlan == criterios.IdPlan);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<Socio?> ObtenerPorIdAsync(int id)
        {
            return await _context.Socios
                .FirstOrDefaultAsync(s => s.PersonaId == id);
        }

        public async Task AgregarAsync(Socio socio)
        {
            await _context.Socios.AddAsync(socio);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Socio socio)
        {
            _context.Socios.Update(socio);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            Socio? socio = await _context.Socios
                .FirstOrDefaultAsync(s => s.PersonaId == id);

            if (socio != null)
            {
                _context.Socios.Remove(socio);
                await _context.SaveChangesAsync();
            }
        }
    }
}