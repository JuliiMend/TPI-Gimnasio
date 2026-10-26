using System.Text.RegularExpressions;

namespace Domain.Model
{
    // Junta los errores de validación de una entidad y los lanza todos juntos
    public class Validador
    {
        public static readonly Regex RegexEmail = new(@"^[^@\s]+@[^@\s]+\.[A-Za-z]{2,}$", RegexOptions.Compiled);
        public static readonly Regex RegexDni = new(@"^\d{7,8}$", RegexOptions.Compiled);
        public static readonly Regex RegexTelefono = new(@"^\+?\d{6,15}$", RegexOptions.Compiled);
        public static readonly Regex RegexUsername = new(@"^[A-Za-z0-9._-]{3,50}$", RegexOptions.Compiled);
        public static readonly Regex RegexNombre = new(@"^[\p{L}][\p{L} '.-]*$", RegexOptions.Compiled);

        public const int LargoMinimoPassword = 8;
        public const int LargoMaximoPassword = 100;

        private readonly List<string> _errores = new();

        public Validador Requerido(string? valor, string campo, int largoMaximo = 100)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                _errores.Add($"{campo} es obligatorio.");
            }
            else if (valor.Trim().Length > largoMaximo)
            {
                _errores.Add($"{campo} no puede superar los {largoMaximo} caracteres.");
            }

            return this;
        }

        public Validador Formato(string? valor, Regex regex, string mensaje)
        {
            if (!string.IsNullOrWhiteSpace(valor) && !regex.IsMatch(valor.Trim()))
            {
                _errores.Add(mensaje);
            }

            return this;
        }

        public Validador Regla(bool condicion, string mensaje)
        {
            if (!condicion)
            {
                _errores.Add(mensaje);
            }

            return this;
        }

        public void Lanzar()
        {
            if (_errores.Count > 0)
            {
                throw new ValidacionDominioException(string.Join(" ", _errores));
            }
        }

        public static void ValidarPassword(string? password)
        {
            new Validador()
                .Regla(!string.IsNullOrEmpty(password) &&
                       password.Length >= LargoMinimoPassword && password.Length <= LargoMaximoPassword,
                       $"La contraseña debe tener entre {LargoMinimoPassword} y {LargoMaximoPassword} caracteres.")
                .Regla(!string.IsNullOrEmpty(password) && password.Any(char.IsLetter) && password.Any(char.IsDigit),
                       "La contraseña debe contener al menos una letra y un número.")
                .Lanzar();
        }
    }
}
