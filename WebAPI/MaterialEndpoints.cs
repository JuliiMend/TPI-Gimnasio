using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class MaterialEndpoints
    {
        public static void MapMaterialEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/materiales").RequireAuthorization(Politicas.SoloAdmin);

            grupo.MapGet("/", async (IMaterialService materialService) =>
            {
                var materiales = await materialService.ObtenerTodosAsync();
                return Results.Ok(materiales);
            });

            grupo.MapGet("/{id}", async (int id, IMaterialService materialService) =>
            {
                var material = await materialService.ObtenerPorIdAsync(id);
                return material is null ? Results.NotFound() : Results.Ok(material);
            });

            grupo.MapPost("/", async (MaterialCreaActualizaDTO dto, IMaterialService materialService) =>
            {
                var id = await materialService.AgregarAsync(dto);
                var material = await materialService.ObtenerPorIdAsync(id);
                return Results.Created($"/api/materiales/{id}", material);
            });

            grupo.MapPut("/{id}", async (int id, MaterialCreaActualizaDTO dto, IMaterialService materialService) =>
            {
                await materialService.ActualizarAsync(id, dto);
                return Results.NoContent();
            });

            grupo.MapDelete("/{id}", async (int id, IMaterialService materialService) =>
            {
                await materialService.EliminarAsync(id);
                return Results.NoContent();
            });
        }
    }
}
