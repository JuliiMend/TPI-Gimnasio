namespace Domain.Model
{
    public class Maquina
    {
        public int IdMaquina { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        public static readonly string[] EstadosValidos = { "Operativa", "En mantenimiento", "Fuera de servicio" };

        public void Validar()
        {
            new Validador()
                .Requerido(Nombre, "El nombre de la máquina", 100)
                .Requerido(Descripcion, "La descripción", 500)
                .Requerido(Tipo, "El tipo", 50)
                .Regla(EstadosValidos.Contains(Estado),
                       $"El estado debe ser uno de: {string.Join(", ", EstadosValidos)}.")
                .Lanzar();
        }
    }
}
