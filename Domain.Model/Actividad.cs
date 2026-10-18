using System.Collections.Generic;

namespace Domain.Model
{
    public class Actividad
    {
        public int IdActividad { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public List<Plan> Planes { get; set; } = new();
    }
}
