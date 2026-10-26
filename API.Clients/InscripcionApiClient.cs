using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class InscripcionApiClient : BaseApiClient
    {
        public static async Task<IEnumerable<InscripcionMostrarDTO>> GetAllAsync(int? idClase = null)
        {
            using var client = await CreateHttpClientAsync();
            var url = idClase.HasValue ? $"api/inscripciones?idClase={idClase.Value}" : "api/inscripciones";
            var result = await client.GetFromJsonAsync<IEnumerable<InscripcionMostrarDTO>>(url);
            return result ?? new List<InscripcionMostrarDTO>();
        }

        public static async Task<PaginaDTO<InscripcionMostrarDTO>> GetPaginadoAsync(int pagina, int tamanio, int? idClase = null)
        {
            using var client = await CreateHttpClientAsync();
            var url = ConParametros("api/inscripciones/paginado", ("pagina", pagina), ("tamanio", tamanio), ("idClase", idClase));
            var result = await client.GetFromJsonAsync<PaginaDTO<InscripcionMostrarDTO>>(url);
            return result ?? new PaginaDTO<InscripcionMostrarDTO>();
        }

        public static async Task AddAsync(InscripcionCreaDTO inscripcion)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/inscripciones", inscripcion);
            await EnsureSuccessAsync(response);
        }

        public static async Task DeleteAsync(int id)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.DeleteAsync($"api/inscripciones/{id}");
            await EnsureSuccessAsync(response);
        }
    }
}
