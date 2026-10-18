namespace DTOs
{
    public class InscripcionMostrarDTO
    {
        public int IdInscripcion { get; set; }
        public int IdSocio { get; set; }
        public string Socio { get; set; } = string.Empty;
        public int IdClase { get; set; }
        public string Clase { get; set; } = string.Empty;
        public DateTime FechaInscripcion { get; set; }
    }
}
