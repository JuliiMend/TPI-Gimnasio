using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class PlanEndpoints
    {
        public static void MapPlanEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/planes");

            grupo.MapGet("/", async (IPlanService planService) =>
            {
                var planes = await planService.ObtenerTodosAsync();
                return Results.Ok(planes);
            });

            grupo.MapGet("/{id}", async (int id, IPlanService planService) =>
            {
                var plan = await planService.ObtenerPorIdAsync(id);
                return plan is null ? Results.NotFound() : Results.Ok(plan);
            });
        }
    }
}