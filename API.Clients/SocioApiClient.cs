using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class SocioApiClient : BaseApiClient
    {
        public static async Task<SocioMostrarDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            return await client.GetFromJsonAsync<SocioMostrarDTO>($"api/socios/{id}");
        }

        public static async Task<IEnumerable<SocioMostrarDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var result = await client.GetFromJsonAsync<IEnumerable<SocioMostrarDTO>>("api/socios");
            return result ?? new List<SocioMostrarDTO>();
        }

        public static async Task AddAsync(SocioCreaActualizaDTO socio)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/socios", socio);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(int id, SocioCreaActualizaDTO socio)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/socios/{id}", socio);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/socios/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}