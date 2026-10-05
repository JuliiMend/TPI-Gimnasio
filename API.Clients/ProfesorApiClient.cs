using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class ProfesorApiClient : BaseApiClient
    {
        public static async Task<ProfesorMostrarDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            return await client.GetFromJsonAsync<ProfesorMostrarDTO>($"api/profesores/{id}");
        }

        public static async Task<IEnumerable<ProfesorMostrarDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var result = await client.GetFromJsonAsync<IEnumerable<ProfesorMostrarDTO>>("api/profesores");
            return result ?? new List<ProfesorMostrarDTO>();
        }

        public static async Task AddAsync(ProfesorCreaActualizaDTO profesor)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/profesores", profesor);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(int id, ProfesorCreaActualizaDTO profesor)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/profesores/{id}", profesor);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/profesores/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}