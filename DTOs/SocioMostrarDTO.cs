using System;

namespace DTOs
{
    public class SocioMostrarDTO
    {
        public int IdPersona { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public DateTime FechaNac { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int IdPlan { get; set; }
        public string NombrePlan { get; set; } = string.Empty; 
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool UsuarioActivo { get; set; }
    }
}