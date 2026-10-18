using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IClaseRepository
    {
        Task<List<Clase>> ObtenerTodosAsync();
        Task<Clase?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Clase clase);
        Task ActualizarAsync(Clase clase);
        Task EliminarAsync(int id);
    }
}
