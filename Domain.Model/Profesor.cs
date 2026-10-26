namespace Domain.Model
{
    public class Profesor : Persona
    {
        public string Cargo { get; set; } = string.Empty;

        public override void Validar()
        {
            ValidarDatosPersonales()
                .Requerido(Cargo, "El cargo", 100)
                .Lanzar();
        }
    }
}
