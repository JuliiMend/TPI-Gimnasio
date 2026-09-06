using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebAPI
{
    public static class UsuarioEndpoints
    {
        public static void MapUsuarioEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/usuarios");

            grupo.MapGet("/", async (IUsuarioService usuarioService) =>
            {
                var usuarios = await usuarioService.ObtenerTodosAsync();
                return Results.Ok(usuarios);
            });

            grupo.MapGet("/{id}", async (int id, IUsuarioService usuarioService) =>
            {
                var usuario = await usuarioService.ObtenerPorIdAsync(id);
                return usuario is null ? Results.NotFound() : Results.Ok(usuario);
            });

            grupo.MapPost("/", async (UsuarioCreaActualizaDTO dto, IUsuarioService usuarioService) =>
            {
                await usuarioService.AgregarAsync(dto);
                return Results.Ok("Usuario creado con éxito");
            });

            grupo.MapPut("/{id}", async (int id, UsuarioCreaActualizaDTO dto, IUsuarioService usuarioService) =>
            {
                await usuarioService.ActualizarAsync(id, dto);
                return Results.Ok("Usuario actualizado con éxito");
            });

            grupo.MapDelete("/{id}", async (int id, IUsuarioService usuarioService) =>
            {
                await usuarioService.EliminarAsync(id);
                return Results.Ok("Usuario eliminado con éxito");
            });
        }
    }
}