using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class CuotaApiClient : BaseApiClient
    {
        public static async Task<CuotaMostrarDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            return await client.GetFromJsonAsync<CuotaMostrarDTO>($"api/cuotas/{id}");
        }

        public static async Task<IEnumerable<CuotaMostrarDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var result = await client.GetFromJsonAsync<IEnumerable<CuotaMostrarDTO>>("api/cuotas");
            return result ?? new List<CuotaMostrarDTO>();
        }

        public static async Task AddAsync(CuotaCreaActualizaDTO cuota)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/cuotas", cuota);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(int id, CuotaCreaActualizaDTO cuota)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/cuotas/{id}", cuota);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(CuotaCreaActualizaDTO cuota)
        {
            await UpdateAsync(cuota.CuotaId, cuota);
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/cuotas/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}