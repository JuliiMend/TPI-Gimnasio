using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IClaseService
    {
        Task<List<ClaseMostrarDTO>> ObtenerTodosAsync();
        Task<ClaseMostrarDTO?> ObtenerPorIdAsync(int id);
        Task<int> AgregarAsync(ClaseCreaActualizaDTO claseDto);
        Task ActualizarAsync(int id, ClaseCreaActualizaDTO claseDto);
        Task EliminarAsync(int id);
    }
}
