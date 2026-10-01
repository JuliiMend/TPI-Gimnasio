using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Clients
{
    public class ProfesorApiClient : BaseApiClient
    {
        public static async Task<ProfesorCreaActualizaDTO> GetAsync(int id)
        {
            return await Task.FromResult(new ProfesorCreaActualizaDTO());
        }

        public static async Task<IEnumerable<ProfesorMostrarDTO>> GetAllAsync()
        {
            return await Task.FromResult(new List<ProfesorMostrarDTO>());
        }

        public static async Task AddAsync(ProfesorCreaActualizaDTO profesor)
        {
            await Task.CompletedTask;
        }

        public static async Task UpdateAsync(ProfesorCreaActualizaDTO profesor)
        {
            await Task.CompletedTask;
        }

        public static async Task DeleteAsync(int id)
        {
            await Task.CompletedTask;
        }
    }
}