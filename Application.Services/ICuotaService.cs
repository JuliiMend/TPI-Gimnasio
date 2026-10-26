using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace Application.Services
{
    public interface ICuotaService
    {
        Task<List<CuotaMostrarDTO>> ObtenerTodosAsync(int? idSocio = null);
        Task<PaginaDTO<CuotaMostrarDTO>> ObtenerPaginadoAsync(int? idSocio, int? mes, int? anio, int numeroPagina, int tamanioPagina);
        Task<CuotaMostrarDTO?> ObtenerPorIdAsync(int id);
        Task<int> AgregarAsync(CuotaCreaActualizaDTO cuotaDto);
        Task ActualizarAsync(int id, CuotaCreaActualizaDTO cuotaDto);
        Task EliminarAsync(int id);
    }
}
