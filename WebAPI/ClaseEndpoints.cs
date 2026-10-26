using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;

namespace WebAPI
{
    public static class ClaseEndpoints
    {
        public static void MapClaseEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/clases").RequireAuthorization();

            grupo.MapGet("/", async (ClaimsPrincipal user, IClaseService claseService, IProfesorService profesorService) =>
            {
                int? idProfesor = user.EsProfesor() ? await user.IdProfesorAsync(profesorService) : null;

                var clases = await claseService.ObtenerTodosAsync(idProfesor);
                return Results.Ok(clases);
            });

            grupo.MapGet("/{id}", async (int id, ClaimsPrincipal user, IClaseService claseService, IProfesorService profesorService) =>
            {
                var clase = await claseService.ObtenerPorIdAsync(id);

                if (clase is null)
                {
                    return Results.NotFound();
                }

                if (user.EsProfesor() && clase.IdProfesor != await user.IdProfesorAsync(profesorService))
                {
                    return Results.Forbid();
                }

                return Results.Ok(clase);
            });

            grupo.MapPost("/", async (ClaseCreaActualizaDTO dto, IClaseService claseService) =>
            {
                var id = await claseService.AgregarAsync(dto);
                var clase = await claseService.ObtenerPorIdAsync(id);
                return Results.Created($"/api/clases/{id}", clase);
            }).RequireAuthorization(Politicas.SoloAdmin);

            grupo.MapPut("/{id}", async (int id, ClaseCreaActualizaDTO dto, IClaseService claseService) =>
            {
                await claseService.ActualizarAsync(id, dto);
                return Results.NoContent();
            }).RequireAuthorization(Politicas.SoloAdmin);

            grupo.MapDelete("/{id}", async (int id, IClaseService claseService) =>
            {
                await claseService.EliminarAsync(id);
                return Results.NoContent();
            }).RequireAuthorization(Politicas.SoloAdmin);
        }
    }
}
