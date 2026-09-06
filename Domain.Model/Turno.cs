using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }

    }
}