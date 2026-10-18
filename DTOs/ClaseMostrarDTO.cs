namespace DTOs
{
    public class ClaseMostrarDTO
    {
        public int IdClase { get; set; }
        public int IdActividad { get; set; }
        public string Actividad { get; set; } = string.Empty;
        public int IdProfesor { get; set; }
        public string Profesor { get; set; } = string.Empty;
        public int IdTurno { get; set; }
        public string Turno { get; set; } = string.Empty;
        public int Cupo { get; set; }
        public int Inscriptos { get; set; }
    }
}
