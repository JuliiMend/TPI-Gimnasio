using Domain.Model;

namespace Data
{
    public static class DatosEnMemoria
    {
        public static List<Plan> Planes { get; } = new()
        {
            new Plan
            {
                IdPlan = 1,
                Nombre = "Premium",
                Tipo = "Musculación",
                Precio = 25000
            },
            new Plan
            {
                IdPlan = 2,
                Nombre = "Básico",
                Tipo = "Cardio",
                Precio = 18000
            }
        };
        public static List<Socio> Socios { get; } = new();
    }
}