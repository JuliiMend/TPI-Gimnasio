using System;
using System.Linq;
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
            var handler = new SesionHandler
            {
                InnerHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                }
            };

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri(BaseUrl)
            };

            try
            {
                if (AuthServiceProvider.Instance != null)
                {
                    await AuthServiceProvider.Instance.CheckTokenExpirationAsync();

                    var token = await AuthServiceProvider.Instance.GetTokenAsync();
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                }
            }
            catch
            {
            }

            return client;
        }

        // Arma "ruta?clave=valor&..." omitiendo los parámetros nulos o vacíos
        protected static string ConParametros(string ruta, params (string Nombre, object? Valor)[] parametros)
        {
            var query = parametros
                .Where(p => p.Valor != null && !string.IsNullOrWhiteSpace(p.Valor.ToString()))
                .Select(p => $"{p.Nombre}={Uri.EscapeDataString(p.Valor!.ToString()!)}");

            var queryString = string.Join("&", query);
            return queryString.Length > 0 ? $"{ruta}?{queryString}" : ruta;
        }

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
            }

            throw new HttpRequestException(mensaje, null, response.StatusCode);
        }
    }
}