using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DetalleCuotaCreaActualizaDTO
    {
        public string Concepto { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal Monto { get; set; }
    }
}
