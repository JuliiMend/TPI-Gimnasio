using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public interface ICuotaRepository
    {
        Task<List<Cuota>> ObtenerTodosAsync();
        Task<Cuota?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Cuota cuota);
        Task ActualizarAsync(Cuota cuota);
        Task EliminarAsync(int id);
    }
}
