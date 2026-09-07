namespace DTOs
{
    public class ProfesorDTO
    {
        public int IdPersona { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public DateTime FechaNac { get; set; }
        public string Cargo { get; set; } = string.Empty;
    }
}