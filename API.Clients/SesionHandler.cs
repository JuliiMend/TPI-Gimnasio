using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace API.Clients
{
    public class SesionHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (request.Headers.Authorization != null)
                {
                    await AuthServiceProvider.Instance.LogoutAsync();
                }

                throw new HttpRequestException("Tu sesión expiró o no es válida. Volvé a iniciar sesión.", null, response.StatusCode);
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new HttpRequestException("No tenés permisos para realizar esta operación.", null, response.StatusCode);
            }

            return response;
        }
    }
}
