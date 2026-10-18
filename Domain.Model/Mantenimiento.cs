using System;

namespace Domain.Model
{
    public class Mantenimiento
    {
        public int IdMantenimiento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinEsperada { get; set; }
        public DateTime? FechaFinReal { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public int IdMaquina { get; set; }
        public Maquina? Maquina { get; set; }
    }
}
