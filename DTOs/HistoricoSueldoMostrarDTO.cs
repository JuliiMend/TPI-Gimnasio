namespace DTOs
{
    public class HistoricoSueldoMostrarDTO
    {
        public int IdHistoricoSueldo { get; set; }
        public int IdProfesor { get; set; }
        public string Profesor { get; set; } = string.Empty;
        public DateTime FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public decimal Valor { get; set; }
        public bool Vigente { get; set; }
    }
}
