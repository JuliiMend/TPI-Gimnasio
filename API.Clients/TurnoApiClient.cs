using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Clients
{
    public class TurnoApiClient : BaseApiClient
    {
        public static async Task<TurnoCreaActualizaDTO> GetAsync(int id)
        {
            return await Task.FromResult(new TurnoCreaActualizaDTO());
        }

        public static async Task<IEnumerable<TurnoMostrarDTO>> GetAllAsync()
        {
            return await Task.FromResult(new List<TurnoMostrarDTO>());
        }

        public static async Task AddAsync(TurnoCreaActualizaDTO turno)
        {
            await Task.CompletedTask;
        }

        public static async Task UpdateAsync(TurnoCreaActualizaDTO turno)
        {
            await Task.CompletedTask;
        }

        public static async Task DeleteAsync(int id)
        {
            await Task.CompletedTask;
        }
    }
}