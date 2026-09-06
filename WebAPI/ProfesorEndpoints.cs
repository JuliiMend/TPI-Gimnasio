using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class ProfesorEndpoints
    {
        public static void MapProfesorEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/profesores");

            grupo.MapGet("/", async (IProfesorService profesorService) =>
            {
                var profesores = await profesorService.ObtenerTodosAsync();
                return Results.Ok(profesores);
            });

            grupo.MapGet("/{id}", async (int id, IProfesorService profesorService) =>
            {
                var profesor = await profesorService.ObtenerPorIdAsync(id);
                return profesor is null ? Results.NotFound() : Results.Ok(profesor);
            });

            grupo.MapPost("/", async (ProfesorCreaActualizaDTO dto, IProfesorService profesorService) =>
            {
                await profesorService.AgregarAsync(dto);
                return Results.Ok("Profesor creado con éxito");
            });

            grupo.MapPut("/{id}", async (int id, ProfesorCreaActualizaDTO dto, IProfesorService profesorService) =>
            {
                await profesorService.ActualizarAsync(id, dto);
                return Results.Ok("Profesor actualizado con éxito");
            });

            grupo.MapDelete("/{id}", async (int id, IProfesorService profesorService) =>
            {
                await profesorService.EliminarAsync(id);
                return Results.Ok("Profesor eliminado con éxito");
            });
        }
    }
}