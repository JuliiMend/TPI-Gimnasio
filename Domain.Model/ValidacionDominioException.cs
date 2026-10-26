namespace Domain.Model
{
    // Datos que no cumplen las reglas del modelo de dominio (formato, obligatorios, rangos)
    public class ValidacionDominioException : Exception
    {
        public ValidacionDominioException(string mensaje) : base(mensaje)
        {
        }
    }
}
