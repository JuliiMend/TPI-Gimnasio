using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GimnasioContext _context;

        public UsuarioRepository(GimnasioContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Pagina<Usuario>> ObtenerPaginadoAsync(int numeroPagina, int tamanioPagina)
        {
            return await _context.Usuarios
                .OrderBy(u => u.Username)
                .ThenBy(u => u.UsuarioId)
                .PaginarAsync(numeroPagina, tamanioPagina);
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.UsuarioId == id);
        }

        public async Task<Usuario?> ObtenerPorUsernameAsync(string username)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Username == username && u.Activo);
        }

        public async Task AgregarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteUsernameAsync(string username, int? exceptoId = null)
        {
            return await _context.Usuarios
                .AnyAsync(u => u.Username == username && u.UsuarioId != exceptoId);
        }

        public async Task<bool> ExisteEmailAsync(string email, int? exceptoId = null)
        {
            return await _context.Usuarios
                .AnyAsync(u => u.Email == email && u.UsuarioId != exceptoId);
        }

        public async Task<int> ContarAdministradoresActivosAsync()
        {
            return await _context.Usuarios
                .CountAsync(u => u.Rol == "Admin" && u.Activo);
        }

        public async Task EliminarAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}