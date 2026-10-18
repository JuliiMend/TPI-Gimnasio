using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IMaquinaRepository
    {
        Task<List<Maquina>> ObtenerTodosAsync();
        Task<Maquina?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Maquina maquina);
        Task ActualizarAsync(Maquina maquina);
        Task EliminarAsync(int id);
    }
}
