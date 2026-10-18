using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class HistoricoSueldoEndpoints
    {
        public static void MapHistoricoSueldoEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/historico-sueldos").RequireAuthorization();

            grupo.MapGet("/", async (int? idProfesor, IHistoricoSueldoService historicoSueldoService) =>
            {
                var sueldos = await historicoSueldoService.ObtenerTodosAsync(idProfesor);
                return Results.Ok(sueldos);
            });

            // Solo alta: el histórico no se modifica ni se borra
            grupo.MapPost("/", async (HistoricoSueldoCreaDTO dto, IHistoricoSueldoService historicoSueldoService) =>
            {
                var id = await historicoSueldoService.RegistrarAsync(dto);
                return Results.Created($"/api/historico-sueldos/{id}", new { idHistoricoSueldo = id });
            });
        }
    }
}
