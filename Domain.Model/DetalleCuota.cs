namespace Domain.Model
{
    public class DetalleCuota
    {
        public int DetalleCuotaId { get; set; }
        public int CuotaId { get; set; }
        public Cuota? Cuota { get; set; }
        public string Concepto { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal Monto { get; set; }

        public void Validar()
        {
            new Validador()
                .Requerido(Concepto, "El concepto del ítem", 200)
                .Regla(Subtotal > 0, $"El subtotal del ítem '{Concepto}' debe ser mayor a 0.")
                .Regla(Monto > 0, $"El monto del ítem '{Concepto}' debe ser mayor a 0.")
                .Lanzar();
        }
    }
}
