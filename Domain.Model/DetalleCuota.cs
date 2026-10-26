using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class DetalleCuota
    {
        public int DetalleCuotaId { get; set; }
        public int CuotaId { get; set; }
        public Cuota? Cuota { get; set; } 
        public string Concepto { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal Monto { get; set; }
    }
}
