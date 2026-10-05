using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITurnoService
    {
        Task<List<TurnoMostrarDTO>> ObtenerTodosAsync();
        Task<TurnoMostrarDTO?> ObtenerPorIdAsync(int id);
        Task<int> AgregarAsync(TurnoCreaActualizaDTO turnoDto);
        Task ActualizarAsync(int id, TurnoCreaActualizaDTO turnoDto);
        Task EliminarAsync(int id);
    }
}
