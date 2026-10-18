using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class ActividadApiClient : BaseApiClient
    {
        public static async Task<ActividadMostrarDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            return await client.GetFromJsonAsync<ActividadMostrarDTO>($"api/actividades/{id}");
        }

        public static async Task<IEnumerable<ActividadMostrarDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var result = await client.GetFromJsonAsync<IEnumerable<ActividadMostrarDTO>>("api/actividades");
            return result ?? new List<ActividadMostrarDTO>();
        }

        public static async Task AddAsync(ActividadCreaActualizaDTO actividad)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/actividades", actividad);
            await EnsureSuccessAsync(response);
        }

        public static async Task UpdateAsync(int id, ActividadCreaActualizaDTO actividad)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/actividades/{id}", actividad);
            await EnsureSuccessAsync(response);
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/actividades/{id}");
            await EnsureSuccessAsync(response);
        }
    }
}