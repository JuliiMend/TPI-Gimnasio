using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IInscripcionService
    {
        Task<List<InscripcionMostrarDTO>> ObtenerTodosAsync(int? idClase, int? idSocio = null, int? idProfesor = null);
        Task<PaginaDTO<InscripcionMostrarDTO>> ObtenerPaginadoAsync(int? idClase, int? idSocio, int? idProfesor, int numeroPagina, int tamanioPagina);
        Task<InscripcionMostrarDTO?> ObtenerPorIdAsync(int id);
        Task<int> InscribirAsync(InscripcionCreaDTO inscripcionDto);
        Task EliminarAsync(int id);
    }
}
