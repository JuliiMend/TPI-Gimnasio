namespace Domain.Model
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public List<Actividad> Actividades { get; set; } = new();

        public const decimal PrecioMaximo = 10_000_000m;

        public void Validar()
        {
            new Validador()
                .Requerido(Nombre, "El nombre del plan", 100)
                .Requerido(Tipo, "El tipo de plan", 50)
                .Regla(Precio > 0 && Precio <= PrecioMaximo, $"El precio debe ser mayor a 0 y menor a {PrecioMaximo:N0}.")
                .Regla((Descripcion ?? string.Empty).Length <= 500, "La descripción no puede superar los 500 caracteres.")
                .Lanzar();
        }
    }
}
