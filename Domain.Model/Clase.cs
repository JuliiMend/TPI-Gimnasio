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
    }
}
