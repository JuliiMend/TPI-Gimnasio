using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly GimnasioContext _context;

        public AdministradorRepository(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<List<Administrador>> ObtenerTodosAsync()
        {
            return await _context.Administradores
                .Include(p => p.Usuario)
                .ToListAsync();
        }

        public async Task<Administrador?> ObtenerPorIdAsync(int id)
        {
            return await _context.Administradores
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.PersonaId == id);
        }

        public async Task AgregarAsync(Administrador administrador)
        {
            await _context.Administradores.AddAsync(administrador);

            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Administrador administrador)
        {
            var administradorTrackeado = _context.Administradores.Local
                .FirstOrDefault(p => p.PersonaId == administrador.PersonaId);

            if (administradorTrackeado != null)
            {
                _context.Entry(administradorTrackeado).State = EntityState.Detached;
            }

            _context.Administradores.Update(administrador);

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            Administrador? administrador = await _context.Administradores
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.PersonaId == id);

            if (administrador != null)
            {
                var usuario = administrador.Usuario;

                _context.Administradores.Remove(administrador);

                if (usuario != null)
                {
                    _context.Usuarios.Remove(usuario);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}