using Application.Services;
using DTOs;
using System.Security.Claims;

namespace WebAPI
{
    public static class Politicas
    {
        public const string SoloAdmin = "SoloAdmin";
        public const string AdminOSocio = "AdminOSocio";
        public const string AdminOProfesor = "AdminOProfesor";
    }

    public static class UsuarioActual
    {
        private const int SinPersona = -1;

        public static int? UsuarioId(this ClaimsPrincipal user)
        {
            return int.TryParse(user.FindFirstValue(ClaimTypes.NameIdentifier), out var id) ? id : null;
        }

        public static bool EsAdmin(this ClaimsPrincipal user) => user.IsInRole(Roles.Admin);
        public static bool EsSocio(this ClaimsPrincipal user) => user.IsInRole(Roles.Socio);
        public static bool EsProfesor(this ClaimsPrincipal user) => user.IsInRole(Roles.Profesor);

        public static async Task<SocioMostrarDTO?> SocioAsync(this ClaimsPrincipal user, ISocioService socioService)
        {
            return user.UsuarioId() is int id ? await socioService.ObtenerPorUsuarioAsync(id) : null;
        }

        public static async Task<int> IdSocioAsync(this ClaimsPrincipal user, ISocioService socioService)
        {
            return (await user.SocioAsync(socioService))?.IdPersona ?? SinPersona;
        }

        public static async Task<int> IdProfesorAsync(this ClaimsPrincipal user, IProfesorService profesorService)
        {
            var profesor = user.UsuarioId() is int id ? await profesorService.ObtenerPorUsuarioAsync(id) : null;
            return profesor?.IdPersona ?? SinPersona;
        }
    }
}
