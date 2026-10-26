using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class MantenimientoEndpoints
    {
        public static void MapMantenimientoEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/mantenimientos").RequireAuthorization(Politicas.SoloAdmin);

            grupo.MapGet("/", async (int? idMaquina, string? estado, IMantenimientoService mantenimientoService) =>
            {
                var mantenimientos = await mantenimientoService.ObtenerTodosAsync(idMaquina, estado);
                return Results.Ok(mantenimientos);
            });

            grupo.MapGet("/paginado", async (int? idMaquina, string? estado, IMantenimientoService mantenimientoService,
                int pagina = 1, int tamanio = 10) =>
            {
                var mantenimientos = await mantenimientoService.ObtenerPaginadoAsync(idMaquina, estado, pagina, tamanio);
                return Results.Ok(mantenimientos);
            });

            grupo.MapGet("/{id}", async (int id, IMantenimientoService mantenimientoService) =>
            {
                var mantenimiento = await mantenimientoService.ObtenerPorIdAsync(id);
                return mantenimiento is null ? Results.NotFound() : Results.Ok(mantenimiento);
            });

            grupo.MapPost("/", async (MantenimientoCreaActualizaDTO dto, IMantenimientoService mantenimientoService) =>
            {
                var id = await mantenimientoService.AgregarAsync(dto);
                var mantenimiento = await mantenimientoService.ObtenerPorIdAsync(id);
                return Results.Created($"/api/mantenimientos/{id}", mantenimiento);
            });

            grupo.MapPut("/{id}", async (int id, MantenimientoCreaActualizaDTO dto, IMantenimientoService mantenimientoService) =>
            {
                await mantenimientoService.ActualizarAsync(id, dto);
                return Results.NoContent();
            });

            grupo.MapDelete("/{id}", async (int id, IMantenimientoService mantenimientoService) =>
            {
                await mantenimientoService.EliminarAsync(id);
                return Results.NoContent();
            });
        }
    }
}
