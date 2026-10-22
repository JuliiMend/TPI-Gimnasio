using System;

namespace Domain.Model
{
    public class HistoricoSueldo
    {
        public int IdHistoricoSueldo { get; set; }
        public DateTime FechaDesde { get; set; }
        public decimal Valor { get; set; }

        public int IdProfesor { get; set; }
        public Profesor? Profesor { get; set; }
    }
}
