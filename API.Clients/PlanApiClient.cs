using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Clients
{
    public class PlanApiClient : BaseApiClient
    {
        public static async Task<PlanCreaActualizaDTO> GetAsync(int id)
        {
            return await Task.FromResult(new PlanCreaActualizaDTO());
        }

        public static async Task<IEnumerable<PlanMostrarDTO>> GetAllAsync()
        {
            return await Task.FromResult(new List<PlanMostrarDTO>());
        }

        public static async Task AddAsync(PlanCreaActualizaDTO plan)
        {
            await Task.CompletedTask;
        }

        public static async Task UpdateAsync(PlanCreaActualizaDTO plan)
        {
            await Task.CompletedTask;
        }

        public static async Task DeleteAsync(int id)
        {
            await Task.CompletedTask;
        }
    }
}