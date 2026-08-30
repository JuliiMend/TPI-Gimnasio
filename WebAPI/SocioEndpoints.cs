using Application.Services;
using DTOs;

namespace WebAPI
{
    public static class SocioEndpoints
    {
        public static void MapSocioEndpoints(this IEndpointRouteBuilder app)
        {
            var grupo = app.MapGroup("/api/socios");
            grupo.MapGet("/", ([AsParameters] SocioCriteriaDTO criterios, ISocioService socioService) =>
            {
                return Results.Ok(socioService.ObtenerTodos(criterios));
            });

            grupo.MapGet("/{id}",(int id, ISocioService socioService) =>
            {
                var socio = socioService.ObtenerPorId(id);
                return socio is null ? Results.NotFound() : Results.Ok(socio);
            });

            grupo.MapPost("/",(SocioCreaActualizaDTO socio, ISocioService socioService) =>
            {
                socioService.Agregar(socio);
                return Results.Created($"/api/socios/{socio.IdPersona}", socio);
            });

            grupo.MapPut("/{id}",(int id, SocioCreaActualizaDTO socio, ISocioService socioService) =>
            {
                socioService.Actualizar(id, socio);
                return Results.NoContent();
            });

            grupo.MapDelete("/{id}",(int id, ISocioService socioService) =>
            {
                socioService.Eliminar(id);
                return Results.NoContent();
            });
        }
    }
}