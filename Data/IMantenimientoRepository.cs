using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IMantenimientoRepository
    {
        Task<List<Mantenimiento>> ObtenerTodosAsync(int? idMaquina);
        Task<Mantenimiento?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Mantenimiento mantenimiento);
        Task ActualizarAsync(Mantenimiento mantenimiento);
        Task EliminarAsync(int id);
    }
}
