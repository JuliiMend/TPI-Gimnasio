using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class AuthEndpoints
    {
        public const string PoliticaLimiteLogin = "LimiteLogin";

        public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/auth");

            grupo.MapPost("/login", async (LoginRequest request, IAuthService authService) =>
            {
                var respuesta = await authService.LoginAsync(request);

                if (respuesta != null && respuesta.Exito)
                {
                    return Results.Ok(respuesta);
                }

                if (respuesta?.Bloqueado == true)
                {
                    return Results.Json(respuesta, statusCode: StatusCodes.Status429TooManyRequests);
                }

                return Results.BadRequest(respuesta ?? new LoginResponse { Exito = false, Mensaje = "Credenciales incorrectas" });
            }).RequireRateLimiting(PoliticaLimiteLogin);
        }
    }
}