using System;

namespace Application.Services
{
    // Se lanza cuando una operación viola una regla del negocio (ej: clase sin cupo).
    // La WebAPI la devuelve como 409 con el mensaje.
    public class ReglaNegocioException : Exception
    {
        public ReglaNegocioException(string mensaje) : base(mensaje)
        {
        }
    }
}
