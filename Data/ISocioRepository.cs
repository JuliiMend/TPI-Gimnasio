using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public interface ISocioRepository
    {
        Task<List<Socio>> ObtenerTodosAsync(SocioCriteria criterios);
        Task<Pagina<Socio>> ObtenerPaginadoAsync(SocioCriteria criterios, int numeroPagina, int tamanioPagina);
        Task<Socio?> ObtenerPorIdAsync(int id);
        Task<Socio?> ObtenerPorUsuarioIdAsync(int usuarioId);
        Task AgregarAsync(Socio socio);
        Task ActualizarAsync(Socio socio);
        Task EliminarAsync(int id);
    }
}