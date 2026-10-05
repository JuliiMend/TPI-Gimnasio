using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class TurnoApiClient : BaseApiClient
    {
        public static async Task<TurnoMostrarDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            return await client.GetFromJsonAsync<TurnoMostrarDTO>($"api/turnos/{id}");
        }

        public static async Task<IEnumerable<TurnoMostrarDTO>> GetAllAsync()
        {
            using var client = await CreateHttpClientAsync();
            var result = await client.GetFromJsonAsync<IEnumerable<TurnoMostrarDTO>>("api/turnos");
            return result ?? new List<TurnoMostrarDTO>();
        }

        public static async Task AddAsync(TurnoCreaActualizaDTO turno)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/turnos", turno);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateAsync(int id, TurnoCreaActualizaDTO turno)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/turnos/{id}", turno);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/turnos/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}