using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/auth");

            grupo.MapPost("/login", async (LoginRequest request, IAuthService authService) =>
            {
                var respuesta = await authService.LoginAsync(request);

                if (respuesta.Exito)
                {
                    return Results.Ok(respuesta);
                }

                return Results.BadRequest(respuesta);
            });
        }
    }
}