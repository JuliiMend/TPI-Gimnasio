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

            grupo.MapGet("/", (ITurnoService turnoService) =>
            {
                return Results.Ok(turnoService.ObtenerTodos());
            });

            grupo.MapGet("/{id}", (int id, ITurnoService turnoService) =>
            {
                var turno = turnoService.ObtenerPorId(id);
                return turno is null ? Results.NotFound() : Results.Ok(turno);
            });

            grupo.MapPost("/", (TurnoCreaActualizaDTO dto, ITurnoService turnoService) =>
            {
                turnoService.Agregar(dto);
                return Results.Ok("Turno creado con éxito");
            });

            grupo.MapPut("/{id}", (int id, TurnoCreaActualizaDTO dto, ITurnoService turnoService) =>
            {
                turnoService.Actualizar(id, dto);
                return Results.Ok("Turno actualizado con éxito");
            });

            grupo.MapDelete("/{id}", (int id, ITurnoService turnoService) =>
            {
                turnoService.Eliminar(id);
                return Results.Ok("Turno eliminado con éxito");
            });
        }
    }
}