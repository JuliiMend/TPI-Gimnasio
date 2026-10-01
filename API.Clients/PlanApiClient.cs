using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class PlanApiClient : BaseApiClient
    {
        public static async Task<PlanMostrarDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            return await client.GetFromJsonAsync<PlanMostrarDTO>($"api/planes/{id}");
        }

        public static async Task<IEnumerable<PlanMostrarDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var result = await client.GetFromJsonAsync<IEnumerable<PlanMostrarDTO>>("api/planes");
            return result ?? new List<PlanMostrarDTO>();
        }

        public static async Task AddAsync(PlanCreaActualizaDTO plan)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/planes", plan);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(int id, PlanCreaActualizaDTO plan)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/planes/{id}", plan);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/planes/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}