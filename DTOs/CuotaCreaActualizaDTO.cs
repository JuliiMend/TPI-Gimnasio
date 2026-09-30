using System;
using System.Collections.Generic;

namespace DTOs
{
    public class CuotaCreaActualizaDTO
    {
        public int CuotaId { get; set; }
        public int SocioId { get; set; }
        public int MesAnio { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Valor { get; set; }

        public List<DetalleCuotaCreaActualizaDTO> Detalles { get; set; } = new();
    }
}
