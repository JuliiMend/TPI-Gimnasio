using DTOs;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public class AuthApiClient : BaseApiClient
    {
        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            using var httpClient = await CreateHttpClientAsync();

            var response = await httpClient.PostAsJsonAsync("api/auth/login", request);

            // 400 (credenciales incorrectas) y 429 (bloqueo por intentos) también traen un LoginResponse con el mensaje
            if (response.IsSuccessStatusCode ||
                response.StatusCode is HttpStatusCode.BadRequest or HttpStatusCode.TooManyRequests)
            {
                try
                {
                    return await response.Content.ReadFromJsonAsync<LoginResponse>();
                }
                catch (System.Text.Json.JsonException)
                {
                }
            }

            return null;
        }
    }
}