using System;

namespace Application.Services
{
    public class ReglaNegocioException : Exception
    {
        public ReglaNegocioException(string mensaje) : base(mensaje)
        {
        }
    }
}
