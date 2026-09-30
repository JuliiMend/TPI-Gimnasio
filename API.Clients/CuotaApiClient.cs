using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Clients
{
    public class CuotaApiClient : BaseApiClient
    {
        public static async Task<CuotaCreaActualizaDTO> GetAsync(int id)
        {
            return await Task.FromResult(new CuotaCreaActualizaDTO());
        }

        public static async Task<IEnumerable<CuotaMostrarDTO>> GetAllAsync()
        {
            return await Task.FromResult(new List<CuotaMostrarDTO>());
        }

        public static async Task AddAsync(CuotaCreaActualizaDTO cuota)
        {
            await Task.CompletedTask;
        }

        public static async Task UpdateAsync(CuotaCreaActualizaDTO cuota)
        {
            await Task.CompletedTask;
        }

        public static async Task DeleteAsync(int id)
        {
            await Task.CompletedTask;
        }
    }
}