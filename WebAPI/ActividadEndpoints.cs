using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class ActividadEndpoints
    {
        public static void MapActividadEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/actividades").RequireAuthorization(Politicas.SoloAdmin);

            grupo.MapGet("/", async (IActividadService actividadService) =>
            {
                var actividades = await actividadService.ObtenerTodosAsync();
                return Results.Ok(actividades);
            });

            grupo.MapGet("/{id}", async (int id, IActividadService actividadService) =>
            {
                var actividad = await actividadService.ObtenerPorIdAsync(id);
                return actividad is null ? Results.NotFound() : Results.Ok(actividad);
            });

            grupo.MapPost("/", async (ActividadCreaActualizaDTO dto, IActividadService actividadService) =>
            {
                var id = await actividadService.AgregarAsync(dto);
                var actividad = await actividadService.ObtenerPorIdAsync(id);
                return Results.Created($"/api/actividades/{id}", actividad);
            });

            grupo.MapPut("/{id}", async (int id, ActividadCreaActualizaDTO dto, IActividadService actividadService) =>
            {
                await actividadService.ActualizarAsync(id, dto);
                return Results.NoContent();
            });

            grupo.MapDelete("/{id}", async (int id, IActividadService actividadService) =>
            {
                await actividadService.EliminarAsync(id);
                return Results.NoContent();
            });
        }
    }
}