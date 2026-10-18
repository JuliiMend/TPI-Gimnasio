using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IActividadRepository
    {
        Task<List<Actividad>> ObtenerTodosAsync();
        Task<List<Actividad>> ObtenerPorIdsAsync(IEnumerable<int> ids);
        Task<Actividad?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Actividad actividad);
        Task ActualizarAsync(Actividad actividad);
        Task EliminarAsync(int id);
    }
}
