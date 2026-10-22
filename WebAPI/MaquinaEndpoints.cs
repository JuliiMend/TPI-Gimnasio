using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class MaquinaEndpoints
    {
        public static void MapMaquinaEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/maquinas").RequireAuthorization();

            grupo.MapGet("/", async (IMaquinaService maquinaService) =>
            {
                var maquinas = await maquinaService.ObtenerTodosAsync();
                return Results.Ok(maquinas);
            });

            grupo.MapGet("/{id}", async (int id, IMaquinaService maquinaService) =>
            {
                var maquina = await maquinaService.ObtenerPorIdAsync(id);
                return maquina is null ? Results.NotFound() : Results.Ok(maquina);
            });

            grupo.MapPost("/", async (MaquinaCreaActualizaDTO dto, IMaquinaService maquinaService) =>
            {
                var id = await maquinaService.AgregarAsync(dto);
                var maquina = await maquinaService.ObtenerPorIdAsync(id);
                return Results.Created($"/api/maquinas/{id}", maquina);
            });

            grupo.MapPut("/{id}", async (int id, MaquinaCreaActualizaDTO dto, IMaquinaService maquinaService) =>
            {
                await maquinaService.ActualizarAsync(id, dto);
                return Results.NoContent();
            });

            grupo.MapDelete("/{id}", async (int id, IMaquinaService maquinaService) =>
            {
                await maquinaService.EliminarAsync(id);
                return Results.NoContent();
            });
        }
    }
}
