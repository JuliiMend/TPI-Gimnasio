using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Model
{
    public class Pagina<T>
    {
        public List<T> Items { get; set; } = new();
        public int NumeroPagina { get; set; }
        public int TamanioPagina { get; set; }
        public int TotalItems { get; set; }

        public const int TamanioMaximo = 100;

        // Ajusta el tamaño a [1, TamanioMaximo] y el número a [1, última página],
        // así al borrar el único ítem de la última página se devuelve la anterior en vez de una vacía
        public static (int NumeroPagina, int TamanioPagina) Normalizar(int numeroPagina, int tamanioPagina, int totalItems)
        {
            tamanioPagina = Math.Clamp(tamanioPagina, 1, TamanioMaximo);
            int ultimaPagina = Math.Max(1, (int)Math.Ceiling(totalItems / (double)tamanioPagina));

            return (Math.Clamp(numeroPagina, 1, ultimaPagina), tamanioPagina);
        }

        // Para listados cuyos campos se calculan en memoria y no se pueden paginar en la base
        public static Pagina<T> Crear(IReadOnlyList<T> todos, int numeroPagina, int tamanioPagina)
        {
            var (numero, tamanio) = Normalizar(numeroPagina, tamanioPagina, todos.Count);

            return new Pagina<T>
            {
                Items = todos.Skip((numero - 1) * tamanio).Take(tamanio).ToList(),
                NumeroPagina = numero,
                TamanioPagina = tamanio,
                TotalItems = todos.Count
            };
        }
    }
}
