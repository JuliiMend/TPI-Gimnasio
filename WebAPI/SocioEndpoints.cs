using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class SocioEndpoints
    {
        public static void MapSocioEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/socios");

            grupo.MapGet("/", async ([AsParameters] SocioCriteriaDTO criterios, ISocioService socioService) =>
            {
                var socios = await socioService.ObtenerTodosAsync(criterios);
                return Results.Ok(socios);
            });

            grupo.MapGet("/{id}", async (int id, ISocioService socioService) =>
            {
                var socio = await socioService.ObtenerPorIdAsync(id);
                return socio is null ? Results.NotFound() : Results.Ok(socio);
            });

            grupo.MapPost("/", async (SocioCreaActualizaDTO socio, ISocioService socioService) =>
            {
                await socioService.AgregarAsync(socio);
                return Results.Created($"/api/socios/{socio.IdPersona}", socio);
            });

            grupo.MapPut("/{id}", async (int id, SocioCreaActualizaDTO socio, ISocioService socioService) =>
            {
                await socioService.ActualizarAsync(id, socio);
                return Results.NoContent();
            });

            grupo.MapDelete("/{id}", async (int id, ISocioService socioService) =>
            {
                await socioService.EliminarAsync(id);
                return Results.NoContent();
            });
        }
    }
}