using Data;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var query = _context.Socios
                .Include(s => s.Plan)
                .Include(s => s.Usuario)
                .AsQueryable();

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
                .Include(s => s.Plan)
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(s => s.PersonaId == id);
        }

        public async Task AgregarAsync(Socio socio)
        {
            await _context.Socios.AddAsync(socio);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Socio socio)
        {
            var socioTrackeado = _context.Socios.Local
                .FirstOrDefault(s => s.PersonaId == socio.PersonaId);

            if (socioTrackeado != null)
            {
                _context.Entry(socioTrackeado).State = EntityState.Detached;
            }

            _context.Socios.Update(socio);

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            Socio? socio = await _context.Socios
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(s => s.PersonaId == id);

            if (socio != null)
            {
                var usuario = socio.Usuario;

                _context.Socios.Remove(socio);

                if (usuario != null)
                {
                    _context.Usuarios.Remove(usuario);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}