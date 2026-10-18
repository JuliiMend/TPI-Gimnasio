using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Clients
{
    public abstract class BaseApiClient
    {
        public static string BaseUrl { get; set; } = "https://localhost:7209/";

        protected static async Task<HttpClient> CreateHttpClientAsync()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri(BaseUrl)
            };

            try
            {
                if (AuthServiceProvider.Instance != null)
                {
                    var token = await AuthServiceProvider.Instance.GetTokenAsync();
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                }
            }
            catch
            {
                // Si aún no se registró AuthServiceProvider, continúa sin token
            }

            return client;
        }

        // Igual que EnsureSuccessStatusCode, pero usa el "mensaje" que devuelve la API cuando existe
        protected static async Task EnsureSuccessAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            string mensaje = $"Error {(int)response.StatusCode} ({response.ReasonPhrase}).";

            try
            {
                var cuerpo = await response.Content.ReadAsStringAsync();
                using var json = JsonDocument.Parse(cuerpo);

                if (json.RootElement.ValueKind == JsonValueKind.Object &&
                    json.RootElement.TryGetProperty("mensaje", out var detalle))
                {
                    mensaje = detalle.GetString() ?? mensaje;
                }
            }
            catch (JsonException)
            {
                // El cuerpo no es JSON: se usa el mensaje genérico
            }

            throw new HttpRequestException(mensaje, null, response.StatusCode);
        }
    }
}