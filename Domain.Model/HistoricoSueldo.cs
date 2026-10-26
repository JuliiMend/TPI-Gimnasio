namespace Domain.Model
{
    public class HistoricoSueldo
    {
        public int IdHistoricoSueldo { get; set; }
        public DateTime FechaDesde { get; set; }
        public decimal Valor { get; set; }

        public int IdProfesor { get; set; }
        public Profesor? Profesor { get; set; }

        public const decimal ValorMaximo = 100_000_000m;

        public void Validar()
        {
            new Validador()
                .Regla(IdProfesor > 0, "Debe seleccionar un profesor.")
                .Regla(FechaDesde.Year >= 2000, "La fecha desde no es válida.")
                .Regla(Valor > 0 && Valor <= ValorMaximo, "El valor del sueldo debe ser mayor a 0.")
                .Lanzar();
        }
    }
}
