using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IInscripcionService
    {
        Task<List<InscripcionMostrarDTO>> ObtenerTodosAsync(int? idClase);
        Task<InscripcionMostrarDTO?> ObtenerPorIdAsync(int id);
        Task<int> InscribirAsync(InscripcionCreaDTO inscripcionDto);
        Task EliminarAsync(int id);
    }
}
