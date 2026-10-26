using System;

namespace Domain.Model
{
    public class Inscripcion
    {
        public int IdInscripcion { get; set; }
        public DateTime FechaInscripcion { get; set; }

        public int IdSocio { get; set; }
        public Socio? Socio { get; set; }

        public int IdClase { get; set; }
        public Clase? Clase { get; set; }
    }
}
