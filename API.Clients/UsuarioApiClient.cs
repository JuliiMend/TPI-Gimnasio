using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Clients
{
    public class UsuarioApiClient : BaseApiClient
    {
        public static async Task<UsuarioCreaActualizaDTO> GetAsync(int id)
        {
            return await Task.FromResult(new UsuarioCreaActualizaDTO());
        }

        public static async Task<IEnumerable<UsuarioMostrarDTO>> GetAllAsync()
        {
            return await Task.FromResult(new List<UsuarioMostrarDTO>());
        }

        public static async Task AddAsync(UsuarioCreaActualizaDTO usuario)
        {
            await Task.CompletedTask;
        }

        public static async Task UpdateAsync(UsuarioCreaActualizaDTO usuario)
        {
            await Task.CompletedTask;
        }

        public static async Task DeleteAsync(int id)
        {
            await Task.CompletedTask;
        }
    }
}