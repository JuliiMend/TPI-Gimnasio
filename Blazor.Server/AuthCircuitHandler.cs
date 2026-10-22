using API.Clients;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace Blazor.Server
{
    // Antes de procesar cada evento del circuito, deja disponible la sesión de ESE usuario
    // para que los ApiClients (estáticos) usen su token y no el de otro navegador.
    public class AuthCircuitHandler : CircuitHandler
    {
        private readonly IAuthService _authService;

        public AuthCircuitHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public override Func<CircuitInboundActivityContext, Task> CreateInboundActivityHandler(
            Func<CircuitInboundActivityContext, Task> next)
        {
            return async context =>
            {
                AuthServiceProvider.SetActual(_authService);
                await next(context);
            };
        }
    }
}
