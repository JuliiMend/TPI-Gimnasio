namespace Domain.Model
{
    public class Cuota
    {
        public int CuotaId { get; set; }
        public int SocioId { get; set; }
        public int MesAnio { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Valor { get; set; }
        public Socio? Socio { get; set; }
        public List<DetalleCuota> Detalles { get; set; } = new();

        // MesAnio se guarda como AAAAMM (ej: 202610)
        public int Mes => MesAnio % 100;
        public int Anio => MesAnio / 100;

        public void Validar()
        {
            var validador = new Validador()
                .Regla(SocioId > 0, "Debe seleccionar un socio.")
                .Regla(Mes >= 1 && Mes <= 12 && Anio >= 2000 && Anio <= 2100,
                       "El período de la cuota no es válido (formato AAAAMM).")
                .Regla(FechaPago.Year >= 2000, "La fecha de pago no es válida.")
                .Regla(FechaPago.Date <= DateTime.Today, "La fecha de pago no puede ser futura.")
                .Regla(Detalles.Count > 0, "La cuota debe tener al menos un ítem de detalle.")
                .Regla(Valor == Detalles.Sum(d => d.Monto), "El valor de la cuota debe coincidir con la suma de los ítems.");

            validador.Lanzar();

            foreach (var detalle in Detalles)
            {
                detalle.Validar();
            }
        }
    }
}
