using System;
using System.Net.Http;
using System.Net.Http.Headers;
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
    }
}