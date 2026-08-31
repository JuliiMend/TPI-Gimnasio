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

            grupo.MapGet("/", (IProfesorService profesorService) =>
            {
                return Results.Ok(profesorService.ObtenerTodos());
            });

            grupo.MapGet("/{id}", (int id, IProfesorService profesorService) =>
            {
                var profesor = profesorService.ObtenerPorId(id);
                return profesor is null ? Results.NotFound() : Results.Ok(profesor);
            });

            grupo.MapPost("/", (ProfesorCreaActualizaDTO dto, IProfesorService profesorService) =>
            {
                profesorService.Agregar(dto);
                return Results.Ok("Profesor creado con éxito");
            });

            grupo.MapPut("/{id}", (int id, ProfesorCreaActualizaDTO dto, IProfesorService profesorService) =>
            {
                profesorService.Actualizar(id, dto);
                return Results.Ok("Profesor actualizado con éxito");
            });

            grupo.MapDelete("/{id}", (int id, IProfesorService profesorService) =>
            {
                profesorService.Eliminar(id);
                return Results.Ok("Profesor eliminado con éxito");
            });
        }
    }
}