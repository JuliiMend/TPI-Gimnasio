using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class MantenimientoApiClient : BaseApiClient
    {
        public static async Task<MantenimientoMostrarDTO?> GetAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            return await client.GetFromJsonAsync<MantenimientoMostrarDTO>($"api/mantenimientos/{id}");
        }

        public static async Task<IEnumerable<MantenimientoMostrarDTO>> GetAllAsync(int? idMaquina = null, string? estado = null)
        {
            using var client = await CreateHttpClientAsync();

            var filtros = new List<string>();
            if (idMaquina.HasValue) filtros.Add($"idMaquina={idMaquina.Value}");
            if (!string.IsNullOrWhiteSpace(estado)) filtros.Add($"estado={Uri.EscapeDataString(estado)}");

            var url = "api/mantenimientos" + (filtros.Count > 0 ? "?" + string.Join("&", filtros) : string.Empty);
            var result = await client.GetFromJsonAsync<IEnumerable<MantenimientoMostrarDTO>>(url);
            return result ?? new List<MantenimientoMostrarDTO>();
        }

        public static async Task AddAsync(MantenimientoCreaActualizaDTO mantenimiento)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/mantenimientos", mantenimiento);
            await EnsureSuccessAsync(response);
        }

        public static async Task UpdateAsync(int id, MantenimientoCreaActualizaDTO mantenimiento)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/mantenimientos/{id}", mantenimiento);
            await EnsureSuccessAsync(response);
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/mantenimientos/{id}");
            await EnsureSuccessAsync(response);
        }
    }
}
