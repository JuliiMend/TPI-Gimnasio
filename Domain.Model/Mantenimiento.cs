namespace Domain.Model
{
    public class Mantenimiento
    {
        public int IdMantenimiento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinEsperada { get; set; }
        public DateTime? FechaFinReal { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public int IdMaquina { get; set; }
        public Maquina? Maquina { get; set; }

        public void Validar()
        {
            new Validador()
                .Regla(IdMaquina > 0, "Debe seleccionar una máquina.")
                .Requerido(Descripcion, "La descripción del mantenimiento", 500)
                .Regla(FechaInicio.Year >= 2000, "La fecha de inicio no es válida.")
                .Regla(FechaFinEsperada.Date >= FechaInicio.Date,
                       "La fecha de fin esperada no puede ser anterior a la fecha de inicio.")
                .Regla(!FechaFinReal.HasValue || FechaFinReal.Value.Date >= FechaInicio.Date,
                       "La fecha de fin real no puede ser anterior a la fecha de inicio.")
                .Regla(!FechaFinReal.HasValue || FechaFinReal.Value.Date <= DateTime.Today,
                       "La fecha de fin real no puede ser futura.")
                .Lanzar();
        }
    }
}
