using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Security.Claims;

namespace WebAPI.Endpoints
{
    public static class CuotaEndpoints
    {
        public static void MapCuotaEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/cuotas").RequireAuthorization(Politicas.AdminOSocio);

            group.MapGet("/", async (ClaimsPrincipal user, ICuotaService cuotaService, ISocioService socioService) =>
            {
                int? idSocio = user.EsSocio() ? await user.IdSocioAsync(socioService) : null;

                var cuotas = await cuotaService.ObtenerTodosAsync(idSocio);
                return Results.Ok(cuotas);
            });

            group.MapGet("/paginado", async (int? idSocio, int? mes, int? anio, ClaimsPrincipal user,
                ICuotaService cuotaService, ISocioService socioService, int pagina = 1, int tamanio = 10) =>
            {
                // Un socio solo ve sus cuotas, sin importar el filtro que mande
                if (user.EsSocio())
                {
                    idSocio = await user.IdSocioAsync(socioService);
                }

                var cuotas = await cuotaService.ObtenerPaginadoAsync(idSocio, mes, anio, pagina, tamanio);
                return Results.Ok(cuotas);
            });

            group.MapGet("/{id}", async (int id, ClaimsPrincipal user, ICuotaService cuotaService, ISocioService socioService) =>
            {
                var cuota = await cuotaService.ObtenerPorIdAsync(id);

                if (cuota is null)
                {
                    return Results.NotFound();
                }

                if (user.EsSocio() && cuota.SocioId != await user.IdSocioAsync(socioService))
                {
                    return Results.Forbid();
                }

                return Results.Ok(cuota);
            });

            group.MapPost("/", async (CuotaCreaActualizaDTO dto, ICuotaService cuotaService) =>
            {
                var id = await cuotaService.AgregarAsync(dto);
                var cuota = await cuotaService.ObtenerPorIdAsync(id);
                return Results.Created($"/api/cuotas/{id}", cuota);
            }).RequireAuthorization(Politicas.SoloAdmin);

            group.MapPut("/{id}", async (int id, CuotaCreaActualizaDTO dto, ICuotaService cuotaService) =>
            {
                try
                {
                    await cuotaService.ActualizarAsync(id, dto);
                    return Results.NoContent();
                }
                catch (Exception)
                {
                    return Results.NotFound();
                }
            }).RequireAuthorization(Politicas.SoloAdmin);

            group.MapDelete("/{id}", async (int id, ICuotaService cuotaService) =>
            {
                await cuotaService.EliminarAsync(id);
                return Results.NoContent();
            }).RequireAuthorization(Politicas.SoloAdmin);
        }
    }
}
