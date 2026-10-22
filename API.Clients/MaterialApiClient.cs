using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class MaterialApiClient : BaseApiClient
    {
        public static async Task<MaterialMostrarDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            return await client.GetFromJsonAsync<MaterialMostrarDTO>($"api/materiales/{id}");
        }

        public static async Task<IEnumerable<MaterialMostrarDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var result = await client.GetFromJsonAsync<IEnumerable<MaterialMostrarDTO>>("api/materiales");
            return result ?? new List<MaterialMostrarDTO>();
        }

        public static async Task AddAsync(MaterialCreaActualizaDTO material)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/materiales", material);
            await EnsureSuccessAsync(response);
        }

        public static async Task UpdateAsync(int id, MaterialCreaActualizaDTO material)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/materiales/{id}", material);
            await EnsureSuccessAsync(response);
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/materiales/{id}");
            await EnsureSuccessAsync(response);
        }
    }
}
