using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class AdministradorApiClient : BaseApiClient
    {
        public static async Task<AdministradorMostrarDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            return await client.GetFromJsonAsync<AdministradorMostrarDTO>($"api/administradores/{id}");
        }

        public static async Task<IEnumerable<AdministradorMostrarDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var result = await client.GetFromJsonAsync<IEnumerable<AdministradorMostrarDTO>>("api/administradores");
            return result ?? new List<AdministradorMostrarDTO>();
        }

        public static async Task AddAsync(AdministradorCreaActualizaDTO administrador)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/administradores", administrador);
            await EnsureSuccessAsync(response);
        }

        public static async Task UpdateAsync(int id, AdministradorCreaActualizaDTO administrador)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/administradores/{id}", administrador);
            await EnsureSuccessAsync(response);
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/administradores/{id}");
            await EnsureSuccessAsync(response);
        }
    }
}