namespace DTOs
{
    public class MantenimientoCreaActualizaDTO
    {
        public int IdMaquina { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinEsperada { get; set; }
        public DateTime? FechaFinReal { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
