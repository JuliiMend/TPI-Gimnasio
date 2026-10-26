using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IMaterialRepository
    {
        Task<List<Material>> ObtenerTodosAsync();
        Task<Material?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Material material);
        Task ActualizarAsync(Material material);
        Task EliminarAsync(int id);
    }
}
