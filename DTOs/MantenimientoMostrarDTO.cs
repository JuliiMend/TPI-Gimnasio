namespace DTOs
{
    public class MantenimientoMostrarDTO
    {
        public int IdMantenimiento { get; set; }
        public int IdMaquina { get; set; }
        public string Maquina { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinEsperada { get; set; }
        public DateTime? FechaFinReal { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public int DiasDemora { get; set; }
    }
}
