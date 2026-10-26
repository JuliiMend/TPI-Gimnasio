using Application.Services;
using DTOs;
using System.Security.Claims;

namespace WebAPI { 
    public static class PlanEndpoints
    {
        public static void MapPlanEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/planes").RequireAuthorization(Politicas.AdminOSocio);
    
            grupo.MapGet("/", async (ClaimsPrincipal user, IPlanService planService, ISocioService socioService) =>
            {
                if (user.EsSocio())
                {
                    var socio = await user.SocioAsync(socioService);
                    var miPlan = socio != null ? await planService.ObtenerPorIdAsync(socio.IdPlan) : null;

                    return Results.Ok(miPlan != null ? new List<PlanMostrarDTO> { miPlan } : new List<PlanMostrarDTO>());
                }

                var planes = await planService.ObtenerTodosAsync();
                return Results.Ok(planes);
            });
    
            grupo.MapGet("/{id}", async (int id, ClaimsPrincipal user, IPlanService planService, ISocioService socioService) =>
            {
                if (user.EsSocio() && (await user.SocioAsync(socioService))?.IdPlan != id)
                {
                    return Results.Forbid();
                }

                var plan = await planService.ObtenerPorIdAsync(id);
                return plan is null ? Results.NotFound() : Results.Ok(plan);
            });
    
            grupo.MapPost("/", async (PlanCreaActualizaDTO dto, IPlanService planService) =>
            {
                var id = await planService.CrearAsync(dto);
                var plan = await planService.ObtenerPorIdAsync(id);
                return Results.Created($"/api/planes/{id}", plan);
            }).RequireAuthorization(Politicas.SoloAdmin);
    
            grupo.MapPut("/{id}", async (int id, PlanCreaActualizaDTO dto, IPlanService planService) =>
            {
                try
                {
                    await planService.ActualizarAsync(id, dto);
                    return Results.NoContent();
                }
                catch (Exception)
                {
                    return Results.NotFound();
                }
            }).RequireAuthorization(Politicas.SoloAdmin);

            grupo.MapDelete("/{id}", async (int id, IPlanService planService) =>
            {
                await planService.EliminarAsync(id);
                return Results.NoContent();
            }).RequireAuthorization(Politicas.SoloAdmin);
        }


    }
}
