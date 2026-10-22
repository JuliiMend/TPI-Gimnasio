using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IMaterialService
    {
        Task<List<MaterialMostrarDTO>> ObtenerTodosAsync();
        Task<MaterialMostrarDTO?> ObtenerPorIdAsync(int id);
        Task<int> AgregarAsync(MaterialCreaActualizaDTO materialDto);
        Task ActualizarAsync(int id, MaterialCreaActualizaDTO materialDto);
        Task EliminarAsync(int id);
    }
}
