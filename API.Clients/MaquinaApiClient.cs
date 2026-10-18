using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class MaquinaApiClient : BaseApiClient
    {
        public static async Task<MaquinaMostrarDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            return await client.GetFromJsonAsync<MaquinaMostrarDTO>($"api/maquinas/{id}");
        }

        public static async Task<IEnumerable<MaquinaMostrarDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var result = await client.GetFromJsonAsync<IEnumerable<MaquinaMostrarDTO>>("api/maquinas");
            return result ?? new List<MaquinaMostrarDTO>();
        }

        public static async Task AddAsync(MaquinaCreaActualizaDTO maquina)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/maquinas", maquina);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(int id, MaquinaCreaActualizaDTO maquina)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/maquinas/{id}", maquina);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/maquinas/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
