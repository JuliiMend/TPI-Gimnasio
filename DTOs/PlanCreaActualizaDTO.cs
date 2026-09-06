using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PlanCreaActualizaDTO
    {
        public string Nombre { get; set; } = string.Empty;  
        public string Tipo { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}