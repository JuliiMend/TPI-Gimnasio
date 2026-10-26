namespace Domain.Model
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public string Rol { get; set; } = string.Empty;

        // La contraseña se valida aparte (Validador.ValidarPassword) porque acá solo se guarda el hash
        public void Validar()
        {
            new Validador()
                .Requerido(Username, "El nombre de usuario", 50)
                .Formato(Username, Validador.RegexUsername,
                         "El nombre de usuario debe tener entre 3 y 50 caracteres (letras, números, punto, guion o guion bajo).")
                .Requerido(Email, "El email", 100)
                .Formato(Email, Validador.RegexEmail, "El email no tiene un formato válido (ejemplo: nombre@mail.com).")
                .Requerido(Rol, "El rol", 20)
                .Lanzar();
        }
    }
}
