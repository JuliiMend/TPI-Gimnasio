namespace Domain.Model
{
    public class Socio : Persona
    {
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int IdPlan { get; set; }
        public Plan? Plan { get; set; }
        public List<Cuota> Cuotas { get; set; } = new List<Cuota>();

        protected override int EdadMinima => 14;

        public override void Validar()
        {
            ValidarDatosPersonales()
                .Regla(FechaAlta.Year >= 1900, "La fecha de alta no es válida.")
                .Regla(FechaAlta.Date <= DateTime.Today, "La fecha de alta no puede ser futura.")
                .Regla(FechaAlta.Date > FechaNac.Date, "La fecha de alta debe ser posterior a la fecha de nacimiento.")
                .Regla(!FechaBaja.HasValue || FechaBaja.Value.Date >= FechaAlta.Date,
                       "La fecha de baja no puede ser anterior a la fecha de alta.")
                .Regla(IdPlan > 0, "El socio debe tener un plan asignado.")
                .Lanzar();
        }
    }
}
