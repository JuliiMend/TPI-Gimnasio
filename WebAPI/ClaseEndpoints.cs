using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class ClaseEndpoints
    {
        public static void MapClaseEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/clases").RequireAuthorization();

            grupo.MapGet("/", async (IClaseService claseService) =>
            {
                var clases = await claseService.ObtenerTodosAsync();
                return Results.Ok(clases);
            });

            grupo.MapGet("/{id}", async (int id, IClaseService claseService) =>
            {
                var clase = await claseService.ObtenerPorIdAsync(id);
                return clase is null ? Results.NotFound() : Results.Ok(clase);
            });

            grupo.MapPost("/", async (ClaseCreaActualizaDTO dto, IClaseService claseService) =>
            {
                var id = await claseService.AgregarAsync(dto);
                var clase = await claseService.ObtenerPorIdAsync(id);
                return Results.Created($"/api/clases/{id}", clase);
            });

            grupo.MapPut("/{id}", async (int id, ClaseCreaActualizaDTO dto, IClaseService claseService) =>
            {
                await claseService.ActualizarAsync(id, dto);
                return Results.NoContent();
            });

            grupo.MapDelete("/{id}", async (int id, IClaseService claseService) =>
            {
                await claseService.EliminarAsync(id);
                return Results.NoContent();
            });
        }
    }
}