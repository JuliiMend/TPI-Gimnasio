using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;

namespace WebAPI
{
    public static class AdministradorEndpoints
    {
        public static void MapAdministradorEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/administradores").RequireAuthorization(Politicas.SoloAdmin);

            grupo.MapGet("/", async (IAdministradorService administradorService) =>
            {
                var administradores = await administradorService.ObtenerTodosAsync();
                return Results.Ok(administradores);
            });

            grupo.MapGet("/{id}", async (int id, IAdministradorService administradorService) =>
            {
                var administrador = await administradorService.ObtenerPorIdAsync(id);
                return administrador is null ? Results.NotFound() : Results.Ok(administrador);
            });

            grupo.MapPost("/", async (AdministradorCreaActualizaDTO dto, IAdministradorService administradorService) =>
            {
                var id = await administradorService.AgregarAsync(dto);
                var administrador = await administradorService.ObtenerPorIdAsync(id);
                return Results.Created($"/api/administradores/{id}", administrador);
            });

            grupo.MapPut("/{id}", async (int id, AdministradorCreaActualizaDTO dto, IAdministradorService administradorService) =>
            {
                await administradorService.ActualizarAsync(id, dto);
                return Results.NoContent();
            });

            grupo.MapDelete("/{id}", async (int id, ClaimsPrincipal user, IAdministradorService administradorService) =>
            {
                await administradorService.EliminarAsync(id, user.UsuarioId());
                return Results.NoContent();
            });
        }
    }
}