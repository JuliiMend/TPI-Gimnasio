using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IMantenimientoService
    {
        Task<List<MantenimientoMostrarDTO>> ObtenerTodosAsync(int? idMaquina, string? estado);
        Task<PaginaDTO<MantenimientoMostrarDTO>> ObtenerPaginadoAsync(int? idMaquina, string? estado, int numeroPagina, int tamanioPagina);
        Task<MantenimientoMostrarDTO?> ObtenerPorIdAsync(int id);
        Task<int> AgregarAsync(MantenimientoCreaActualizaDTO dto);
        Task ActualizarAsync(int id, MantenimientoCreaActualizaDTO dto);
        Task EliminarAsync(int id);
    }
}
