using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;

namespace WebAPI
{
    public static class InscripcionEndpoints
    {
        public static void MapInscripcionEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/inscripciones").RequireAuthorization();

            grupo.MapGet("/", async (int? idClase, ClaimsPrincipal user, IInscripcionService inscripcionService,
                ISocioService socioService, IProfesorService profesorService) =>
            {
                int? idSocio = user.EsSocio() ? await user.IdSocioAsync(socioService) : null;
                int? idProfesor = user.EsProfesor() ? await user.IdProfesorAsync(profesorService) : null;

                var inscripciones = await inscripcionService.ObtenerTodosAsync(idClase, idSocio, idProfesor);
                return Results.Ok(inscripciones);
            });

            grupo.MapGet("/{id}", async (int id, ClaimsPrincipal user, IInscripcionService inscripcionService,
                ISocioService socioService, IProfesorService profesorService, IClaseService claseService) =>
            {
                var inscripcion = await inscripcionService.ObtenerPorIdAsync(id);

                if (inscripcion is null)
                {
                    return Results.NotFound();
                }

                if (user.EsSocio() && inscripcion.IdSocio != await user.IdSocioAsync(socioService))
                {
                    return Results.Forbid();
                }

                if (user.EsProfesor())
                {
                    var clase = await claseService.ObtenerPorIdAsync(inscripcion.IdClase);
                    if (clase?.IdProfesor != await user.IdProfesorAsync(profesorService))
                    {
                        return Results.Forbid();
                    }
                }

                return Results.Ok(inscripcion);
            });

            grupo.MapPost("/", async (InscripcionCreaDTO dto, ClaimsPrincipal user, IInscripcionService inscripcionService,
                ISocioService socioService) =>
            {
                if (user.EsSocio())
                {
                    dto.IdSocio = await user.IdSocioAsync(socioService);
                }

                var id = await inscripcionService.InscribirAsync(dto);
                var inscripcion = await inscripcionService.ObtenerPorIdAsync(id);
                return Results.Created($"/api/inscripciones/{id}", inscripcion);
            }).RequireAuthorization(Politicas.AdminOSocio);

            grupo.MapDelete("/{id}", async (int id, ClaimsPrincipal user, IInscripcionService inscripcionService,
                ISocioService socioService) =>
            {
                if (user.EsSocio())
                {
                    var inscripcion = await inscripcionService.ObtenerPorIdAsync(id);
                    if (inscripcion != null && inscripcion.IdSocio != await user.IdSocioAsync(socioService))
                    {
                        return Results.Forbid();
                    }
                }

                await inscripcionService.EliminarAsync(id);
                return Results.NoContent();
            }).RequireAuthorization(Politicas.AdminOSocio);
        }
    }
}
