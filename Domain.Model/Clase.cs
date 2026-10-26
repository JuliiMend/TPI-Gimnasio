namespace Domain.Model
{
    public class Clase
    {
        public int IdClase { get; set; }
        public int Cupo { get; set; }

        public int IdActividad { get; set; }
        public Actividad? Actividad { get; set; }

        public int IdProfesor { get; set; }
        public Profesor? Profesor { get; set; }

        public int IdTurno { get; set; }
        public Turno? Turno { get; set; }

        public List<Inscripcion> Inscripciones { get; set; } = new();

        public const int CupoMaximo = 200;

        public void Validar()
        {
            new Validador()
                .Regla(IdActividad > 0, "Debe seleccionar una actividad.")
                .Regla(IdProfesor > 0, "Debe seleccionar un profesor.")
                .Regla(IdTurno > 0, "Debe seleccionar un turno.")
                .Regla(Cupo >= 1 && Cupo <= CupoMaximo, $"El cupo debe estar entre 1 y {CupoMaximo}.")
                .Lanzar();
        }
    }
}
