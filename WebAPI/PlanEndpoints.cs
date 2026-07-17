using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class PlanEndpoints
    {
        public static void MapPlanEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/planes");

            grupo.MapGet("/", (IPlanService planService) =>
            {
                return Results.Ok(planService.ObtenerTodos());
            });

            grupo.MapGet("/{id}", (int id, IPlanService planService) =>
            {
                var plan = planService.ObtenerPorId(id);
                return plan is null ? Results.NotFound() : Results.Ok(plan);
            });
        }
    }
}