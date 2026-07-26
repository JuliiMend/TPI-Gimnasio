using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class SocioCreaActualizaDTO
    {
        public int IdPersona { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public DateTime FechaNac { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int IdPlan { get; set; }
    }
}