namespace Domain.Model
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public TimeSpan HoraDesde { get; set; }
        public TimeSpan HoraHasta { get; set; }

        public static readonly string[] DiasValidos =
            { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

        public bool SeSuperponeCon(Turno otro)
        {
            return string.Equals(DiaSemana, otro.DiaSemana, StringComparison.OrdinalIgnoreCase) &&
                   HoraDesde < otro.HoraHasta && otro.HoraDesde < HoraHasta;
        }

        public void Validar()
        {
            new Validador()
                .Regla(DiasValidos.Contains(DiaSemana), "El día de la semana no es válido.")
                .Regla(HoraDesde >= TimeSpan.Zero && HoraHasta < TimeSpan.FromDays(1),
                       "Las horas deben estar entre las 00:00 y las 23:59.")
                .Regla(HoraHasta > HoraDesde, "La hora de fin debe ser posterior a la hora de inicio.")
                .Lanzar();
        }
    }
}
