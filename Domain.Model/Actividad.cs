namespace Domain.Model
{
    public class Actividad
    {
        public int IdActividad { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public List<Plan> Planes { get; set; } = new();

        public void Validar()
        {
            new Validador()
                .Requerido(Tipo, "El tipo de actividad", 50)
                .Requerido(Descripcion, "La descripción", 500)
                .Lanzar();
        }
    }
}
