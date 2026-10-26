using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ObtenerTodosAsync();
        Task<Pagina<Usuario>> ObtenerPaginadoAsync(int numeroPagina, int tamanioPagina);
        Task<Usuario?> ObtenerPorIdAsync(int id);
        Task<Usuario?> ObtenerPorUsernameAsync(string username);
        Task AgregarAsync(Usuario usuario);
        Task ActualizarAsync(Usuario usuario);
        Task<bool> ExisteUsernameAsync(string username, int? exceptoId = null);
        Task<bool> ExisteEmailAsync(string email, int? exceptoId = null);
        Task<int> ContarAdministradoresActivosAsync();
        Task EliminarAsync(int id);
    }
}