using DTOs;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class HistoricoSueldoApiClient : BaseApiClient
    {
        public static async Task<IEnumerable<HistoricoSueldoMostrarDTO>> GetAllAsync(int? idProfesor = null)
        {
            using var client = await CreateHttpClientAsync();
            var url = idProfesor.HasValue ? $"api/historico-sueldos?idProfesor={idProfesor.Value}" : "api/historico-sueldos";
            var result = await client.GetFromJsonAsync<IEnumerable<HistoricoSueldoMostrarDTO>>(url);
            return result ?? new List<HistoricoSueldoMostrarDTO>();
        }

        public static async Task AddAsync(HistoricoSueldoCreaDTO sueldo)
        {
            using var client = await CreateHttpClientAsync();
            var response = await client.PostAsJsonAsync("api/historico-sueldos", sueldo);
            await EnsureSuccessAsync(response);
        }
    }
}
