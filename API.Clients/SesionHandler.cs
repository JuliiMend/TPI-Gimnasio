using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace API.Clients
{
    // Intercepta las respuestas de la API para todos los ApiClients:
    // - 401: el token venció o no es válido -> cierra la sesión (las interfaces vuelven al login)
    // - 403: el rol no tiene permiso -> mensaje claro en lugar del error HTTP genérico
    public class SesionHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            // Puede llegar sin token si el cliente ya detectó el vencimiento y cerró la sesión antes de enviar
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
