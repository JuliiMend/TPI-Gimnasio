namespace DTOs
{
    public class HistoricoSueldoMostrarDTO
    {
        public int IdHistoricoSueldo { get; set; }
        public int IdProfesor { get; set; }
        public string Profesor { get; set; } = string.Empty;
        public DateTime FechaDesde { get; set; }

        // Día anterior al sueldo siguiente del mismo profesor; null = vigente
        public DateTime? FechaHasta { get; set; }
        public decimal Valor { get; set; }
        public bool Vigente { get; set; }
    }
}
