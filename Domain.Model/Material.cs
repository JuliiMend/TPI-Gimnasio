namespace Domain.Model
{
    public class Material
    {
        public int IdMaterial { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int Stock { get; set; }

        public const int StockMaximo = 100_000;

        public void Validar()
        {
            new Validador()
                .Requerido(Descripcion, "La descripción del material", 200)
                .Regla(Stock >= 0 && Stock <= StockMaximo, $"El stock debe estar entre 0 y {StockMaximo:N0}.")
                .Lanzar();
        }
    }
}
