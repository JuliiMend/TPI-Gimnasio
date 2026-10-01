using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Clients
{
    public class SocioApiClient : BaseApiClient
    {
        public static async Task<SocioCreaActualizaDTO> GetAsync(int id)
        {
            return await Task.FromResult(new SocioCreaActualizaDTO
            {
                Username = "",
                Password = "",
                Email = ""
            });
        }

        public static async Task<IEnumerable<SocioMostrarDTO>> GetAllAsync()
        {
            return await Task.FromResult(new List<SocioMostrarDTO>());
        }

        public static async Task AddAsync(SocioCreaActualizaDTO socio)
        {
            await Task.CompletedTask;
        }

        public static async Task UpdateAsync(SocioCreaActualizaDTO socio)
        {
            await Task.CompletedTask;
        }

        public static async Task DeleteAsync(int id)
        {
            await Task.CompletedTask;
        }
    }
}