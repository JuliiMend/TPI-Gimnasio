using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public interface ICuotaRepository
    {
        Task<List<Cuota>> ObtenerTodosAsync(int? idSocio = null);
        Task<Pagina<Cuota>> ObtenerPaginadoAsync(int? idSocio, int? mes, int? anio, int numeroPagina, int tamanioPagina);
        Task<Cuota?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Cuota cuota);
        Task ActualizarAsync(Cuota cuota);
        Task<bool> ExisteAsync(int socioId, int mesAnio, int? exceptoId = null);
        Task EliminarAsync(int id);
    }
}
