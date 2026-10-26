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

        public static async Task<PaginaDTO<SocioMostrarDTO>> GetPaginadoAsync(int pagina, int tamanio, string? dni = null)
        {
            using var client = await CreateHttpClientAsync();
            var url = ConParametros("api/socios/paginado", ("pagina", pagina), ("tamanio", tamanio), ("dni", dni));
            var result = await client.GetFromJsonAsync<PaginaDTO<SocioMostrarDTO>>(url);
            return result ?? new PaginaDTO<SocioMostrarDTO>();
        }

        public static async Task AddAsync(SocioCreaActualizaDTO socio)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/socios", socio);
            await EnsureSuccessAsync(response);
        }

        public static async Task UpdateAsync(int id, SocioCreaActualizaDTO socio)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/socios/{id}", socio);
            await EnsureSuccessAsync(response);
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/socios/{id}");
            await EnsureSuccessAsync(response);
        }
    }
}