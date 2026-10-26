using API.Clients;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace Blazor.Server
{
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
