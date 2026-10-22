using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class ClaseApiClient : BaseApiClient
    {
        public static async Task<ClaseMostrarDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            return await client.GetFromJsonAsync<ClaseMostrarDTO>($"api/clases/{id}");
        }

        public static async Task<IEnumerable<ClaseMostrarDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var result = await client.GetFromJsonAsync<IEnumerable<ClaseMostrarDTO>>("api/clases");
            return result ?? new List<ClaseMostrarDTO>();
        }

        public static async Task AddAsync(ClaseCreaActualizaDTO clase)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/clases", clase);
            await EnsureSuccessAsync(response);
        }

        public static async Task UpdateAsync(int id, ClaseCreaActualizaDTO clase)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/clases/{id}", clase);
            await EnsureSuccessAsync(response);
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/clases/{id}");
            await EnsureSuccessAsync(response);
        }
    }
}