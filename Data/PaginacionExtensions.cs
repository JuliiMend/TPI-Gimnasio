using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public static class PaginacionExtensions
    {
        // La consulta tiene que venir ordenada para que Skip/Take sea estable entre páginas
        public static async Task<Pagina<T>> PaginarAsync<T>(this IQueryable<T> query, int numeroPagina, int tamanioPagina)
        {
            int total = await query.CountAsync();
            var (numero, tamanio) = Pagina<T>.Normalizar(numeroPagina, tamanioPagina, total);

            var items = await query
                .Skip((numero - 1) * tamanio)
                .Take(tamanio)
                .ToListAsync();

            return new Pagina<T>
            {
                Items = items,
                NumeroPagina = numero,
                TamanioPagina = tamanio,
                TotalItems = total
            };
        }
    }
}
