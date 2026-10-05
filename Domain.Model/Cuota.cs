using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Cuota
    {
        public int CuotaId { get; set; }
        public int SocioId { get; set; }
        public int MesAnio { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Valor { get; set; }
        public Socio? Socio { get; set; }
        public List<DetalleCuota> Detalles { get; set; } = new();
    }
}
