using DTOs;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class AuthApiClient : BaseApiClient
    {
        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            /* TODO: Descomentar esto cuando la API de backend esté terminada
            using var httpClient = await CreateHttpClientAsync();

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<LoginResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            return null;
            */

            // SIMULACIÓN: Devolvemos un objeto vacío no-nulo para fingir que la API respondió OK
            return await Task.FromResult(new LoginResponse());
        }
    }
}