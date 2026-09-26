using System;
using System.Collections.Generic;

namespace DTOs
{
    public class CuotaMostrarDTO
    {
        public int CuotaId { get; set; }
        public int SocioId { get; set; }
        public int MesAnio { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Valor { get; set; }
        public string SocioNombre { get; set; } = string.Empty;
        public List<DetalleCuotaMostrarDTO> Detalles { get; set; } = new();
    }
}
