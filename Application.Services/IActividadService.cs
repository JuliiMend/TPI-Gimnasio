using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IActividadService
    {
        Task<List<ActividadMostrarDTO>> ObtenerTodosAsync();
        Task<ActividadMostrarDTO?> ObtenerPorIdAsync(int id);
        Task<int> AgregarAsync(ActividadCreaActualizaDTO actividadDto);
        Task ActualizarAsync(int id, ActividadCreaActualizaDTO actividadDto);
        Task EliminarAsync(int id);
    }
}
