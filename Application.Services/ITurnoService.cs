using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITurnoService
    {
        Task<List<TurnoDTO>> ObtenerTodosAsync();
        Task<TurnoDTO?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(TurnoCreaActualizaDTO turnoDto);
        Task ActualizarAsync(int id, TurnoCreaActualizaDTO turnoDto);
        Task EliminarAsync(int id);
    }
}
