using Application.Services;
using DTOs;

namespace WebAPI.Endpoints
{
    public static class CuotaEndpoints
    {
        public static void MapCuotaEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/cuotas").RequireAuthorization();

            group.MapGet("/", async (ICuotaService cuotaService) =>
            {
                var cuotas = await cuotaService.ObtenerTodosAsync();
                return Results.Ok(cuotas);
            });

            group.MapGet("/{id}", async (int id, ICuotaService cuotaService) =>
            {
                var cuota = await cuotaService.ObtenerPorIdAsync(id);
                return cuota != null ? Results.Ok(cuota) : Results.NotFound();
            });

            group.MapPost("/", async (CuotaCreaActualizaDTO dto, ICuotaService cuotaService) =>
            {
                await cuotaService.AgregarAsync(dto);
                return Results.Created("/api/cuotas", null);
            });

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
            });

            group.MapDelete("/{id}", async (int id, ICuotaService cuotaService) =>
            {
                await cuotaService.EliminarAsync(id);
                return Results.NoContent();
            });
        }
    }
}