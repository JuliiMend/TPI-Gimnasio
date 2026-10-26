namespace Domain.Model
{
    public abstract class Persona
    {
        public int PersonaId { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public DateTime FechaNac { get; set; }
        public int? UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }

        protected virtual int EdadMinima => 18;

        public virtual void Validar()
        {
            ValidarDatosPersonales().Lanzar();
        }

        protected Validador ValidarDatosPersonales()
        {
            return new Validador()
                .Requerido(Dni, "El DNI", 8)
                .Formato(Dni, Validador.RegexDni, "El DNI debe tener 7 u 8 dígitos, sin puntos ni espacios.")
                .Requerido(Nombre, "El nombre", 50)
                .Formato(Nombre, Validador.RegexNombre, "El nombre solo puede contener letras y espacios.")
                .Requerido(Apellido, "El apellido", 50)
                .Formato(Apellido, Validador.RegexNombre, "El apellido solo puede contener letras y espacios.")
                .Requerido(Telefono, "El teléfono", 20)
                .Formato(Telefono, Validador.RegexTelefono, "El teléfono debe tener entre 6 y 15 dígitos (puede empezar con +).")
                .Regla(FechaNac.Year >= 1900, "La fecha de nacimiento no es válida.")
                .Regla(FechaNac.Date <= DateTime.Today.AddYears(-EdadMinima),
                       $"La persona debe tener al menos {EdadMinima} años.");
        }
    }
}
