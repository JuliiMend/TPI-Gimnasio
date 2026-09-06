using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class TurnoEndpoints
    {
        public static void MapTurnoEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/turnos");

            grupo.MapGet("/", async (ITurnoService turnoService) =>
            {
                var turnos = await turnoService.ObtenerTodosAsync();
                return Results.Ok(turnos);
            });

            grupo.MapGet("/{id}", async (int id, ITurnoService turnoService) =>
            {
                var turno = await turnoService.ObtenerPorIdAsync(id);
                return turno is null ? Results.NotFound() : Results.Ok(turno);
            });

            grupo.MapPost("/", async (TurnoCreaActualizaDTO dto, ITurnoService turnoService) =>
            {
                await turnoService.AgregarAsync(dto);
                return Results.Ok("Turno creado con éxito");
            });

            grupo.MapPut("/{id}", async (int id, TurnoCreaActualizaDTO dto, ITurnoService turnoService) =>
            {
                await turnoService.ActualizarAsync(id, dto);
                return Results.Ok("Turno actualizado con éxito");
            });

            grupo.MapDelete("/{id}", async (int id, ITurnoService turnoService) =>
            {
                await turnoService.EliminarAsync(id);
                return Results.Ok("Turno eliminado con éxito");
            });
        }
    }
}