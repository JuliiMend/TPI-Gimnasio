using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Clients
{
    public abstract class BaseApiClient
    {
        protected static async Task<HttpClient> CreateHttpClientAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7209/");

            return await Task.FromResult(client);
        }
    }
}