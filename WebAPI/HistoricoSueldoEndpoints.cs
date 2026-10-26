using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;

namespace WebAPI
{
    public static class HistoricoSueldoEndpoints
    {
        public static void MapHistoricoSueldoEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/historico-sueldos").RequireAuthorization(Politicas.AdminOProfesor);

            grupo.MapGet("/", async (int? idProfesor, ClaimsPrincipal user, IHistoricoSueldoService historicoSueldoService,
                IProfesorService profesorService) =>
            {
                if (user.EsProfesor())
                {
                    idProfesor = await user.IdProfesorAsync(profesorService);
                }

                var sueldos = await historicoSueldoService.ObtenerTodosAsync(idProfesor);
                return Results.Ok(sueldos);
            });

            grupo.MapGet("/paginado", async (int? idProfesor, ClaimsPrincipal user, IHistoricoSueldoService historicoSueldoService,
                IProfesorService profesorService, int pagina = 1, int tamanio = 10) =>
            {
                if (user.EsProfesor())
                {
                    idProfesor = await user.IdProfesorAsync(profesorService);
                }

                var sueldos = await historicoSueldoService.ObtenerPaginadoAsync(idProfesor, pagina, tamanio);
                return Results.Ok(sueldos);
            });

            grupo.MapPost("/", async (HistoricoSueldoCreaDTO dto, IHistoricoSueldoService historicoSueldoService) =>
            {
                var id = await historicoSueldoService.RegistrarAsync(dto);
                return Results.Created($"/api/historico-sueldos/{id}", new { idHistoricoSueldo = id });
            }).RequireAuthorization(Politicas.SoloAdmin);
        }
    }
}
