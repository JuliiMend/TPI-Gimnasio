using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace Application.Services
{
    public interface ICuotaService
    {
        Task<List<CuotaMostrarDTO>> ObtenerTodosAsync();
        Task<CuotaMostrarDTO?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(CuotaCreaActualizaDTO cuotaDto);
        Task ActualizarAsync(int id, CuotaCreaActualizaDTO cuotaDto);
        Task EliminarAsync(int id);
    }
}
