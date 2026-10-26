using DTOs;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    // Junta los errores de validación de un formulario y los muestra todos en un solo mensaje
    internal class ValidacionFormulario
    {
        private readonly List<string> _errores = new();

        public ValidacionFormulario Requerido(string? texto, string campo)
        {
            return Regla(!string.IsNullOrWhiteSpace(texto), $"Completá {campo}.");
        }

        public ValidacionFormulario Regla(bool condicion, string mensaje)
        {
            if (!condicion)
            {
                _errores.Add(mensaje);
            }

            return this;
        }

        // Datos comunes de socios, profesores y administradores
        public ValidacionFormulario Persona(string dni, string nombre, string apellido, string telefono,
            string email, DateTime fechaNac, int edadMinima)
        {
            Regla(ReglasValidacion.DniValido(dni), ReglasValidacion.MensajeDni);
            Regla(ReglasValidacion.NombreValido(nombre), $"Nombre: {ReglasValidacion.MensajeNombre}");
            Regla(ReglasValidacion.NombreValido(apellido), $"Apellido: {ReglasValidacion.MensajeNombre}");
            Regla(ReglasValidacion.TelefonoValido(telefono), ReglasValidacion.MensajeTelefono);
            Regla(ReglasValidacion.EmailValido(email), ReglasValidacion.MensajeEmail);
            Regla(ReglasValidacion.EdadValida(fechaNac, edadMinima), $"Debe tener al menos {edadMinima} años.");

            return this;
        }

        // Muestra los errores (si hay) y devuelve si el formulario es válido
        public bool EsValido()
        {
            if (_errores.Count == 0)
            {
                return true;
            }

            MessageBox.Show(
                "Revisá los siguientes datos:\n\n• " + string.Join("\n• ", _errores),
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }
    }
}
