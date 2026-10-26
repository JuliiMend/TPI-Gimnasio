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

        public static async Task<PaginaDTO<CuotaMostrarDTO>> GetPaginadoAsync(int pagina, int tamanio, int? idSocio = null, int? mes = null, int? anio = null)
        {
            using var client = await CreateHttpClientAsync();
            var url = ConParametros("api/cuotas/paginado", ("pagina", pagina), ("tamanio", tamanio), ("idSocio", idSocio), ("mes", mes), ("anio", anio));
            var result = await client.GetFromJsonAsync<PaginaDTO<CuotaMostrarDTO>>(url);
            return result ?? new PaginaDTO<CuotaMostrarDTO>();
        }

        public static async Task AddAsync(CuotaCreaActualizaDTO cuota)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/cuotas", cuota);
            await EnsureSuccessAsync(response);
        }

        public static async Task UpdateAsync(int id, CuotaCreaActualizaDTO cuota)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PutAsJsonAsync($"api/cuotas/{id}", cuota);
            await EnsureSuccessAsync(response);
        }

        public static async Task UpdateAsync(CuotaCreaActualizaDTO cuota)
        {
            await UpdateAsync(cuota.CuotaId, cuota);
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/cuotas/{id}");
            await EnsureSuccessAsync(response);
        }
    }
}