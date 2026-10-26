using System.Text.RegularExpressions;

namespace DTOs
{
    // Validaciones de formato para las UI (escritorio y web), antes de llamar a la API.
    // Son las mismas reglas que aplica Domain.Model.Validador del lado del servidor.
    public static class ReglasValidacion
    {
        private static readonly Regex RegexEmail = new(@"^[^@\s]+@[^@\s]+\.[A-Za-z]{2,}$");
        private static readonly Regex RegexDni = new(@"^\d{7,8}$");
        private static readonly Regex RegexTelefono = new(@"^\+?\d{6,15}$");
        private static readonly Regex RegexUsername = new(@"^[A-Za-z0-9._-]{3,50}$");
        private static readonly Regex RegexNombre = new(@"^[\p{L}][\p{L} '.-]*$");

        public const int LargoMinimoPassword = 8;

        public const string MensajeEmail = "Ingresá un email válido (ejemplo: nombre@mail.com).";
        public const string MensajeDni = "El DNI debe tener 7 u 8 dígitos, sin puntos ni espacios.";
        public const string MensajeTelefono = "El teléfono debe tener entre 6 y 15 dígitos (puede empezar con +).";
        public const string MensajeUsername = "El usuario debe tener entre 3 y 50 caracteres (letras, números, punto, guion o guion bajo).";
        public const string MensajeNombre = "Solo puede contener letras y espacios.";

        public static bool EmailValido(string? email) => Coincide(RegexEmail, email);
        public static bool DniValido(string? dni) => Coincide(RegexDni, dni);
        public static bool TelefonoValido(string? telefono) => Coincide(RegexTelefono, telefono);
        public static bool UsernameValido(string? username) => Coincide(RegexUsername, username);
        public static bool NombreValido(string? nombre) => Coincide(RegexNombre, nombre) && nombre!.Trim().Length <= 50;

        public static bool EdadValida(DateTime fechaNac, int edadMinima) =>
            fechaNac.Year >= 1900 && fechaNac.Date <= DateTime.Today.AddYears(-edadMinima);

        // Devuelve el problema de la contraseña, o null si es válida
        public static string? ErrorPassword(string? password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < LargoMinimoPassword)
            {
                return $"La contraseña debe tener al menos {LargoMinimoPassword} caracteres.";
            }

            if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                return "La contraseña debe contener al menos una letra y un número.";
            }

            return null;
        }

        private static bool Coincide(Regex regex, string? valor) =>
            !string.IsNullOrWhiteSpace(valor) && regex.IsMatch(valor.Trim());
    }
}
