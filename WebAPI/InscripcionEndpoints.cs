using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class InscripcionEndpoints
    {
        public static void MapInscripcionEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/inscripciones").RequireAuthorization();

            grupo.MapGet("/", async (int? idClase, IInscripcionService inscripcionService) =>
            {
                var inscripciones = await inscripcionService.ObtenerTodosAsync(idClase);
                return Results.Ok(inscripciones);
            });

            grupo.MapGet("/{id}", async (int id, IInscripcionService inscripcionService) =>
            {
                var inscripcion = await inscripcionService.ObtenerPorIdAsync(id);
                return inscripcion is null ? Results.NotFound() : Results.Ok(inscripcion);
            });

            grupo.MapPost("/", async (InscripcionCreaDTO dto, IInscripcionService inscripcionService) =>
            {
                var id = await inscripcionService.InscribirAsync(dto);
                var inscripcion = await inscripcionService.ObtenerPorIdAsync(id);
                return Results.Created($"/api/inscripciones/{id}", inscripcion);
            });

            grupo.MapDelete("/{id}", async (int id, IInscripcionService inscripcionService) =>
            {
                await inscripcionService.EliminarAsync(id);
                return Results.NoContent();
            });
        }
    }
}
