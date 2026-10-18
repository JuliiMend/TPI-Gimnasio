using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IMaquinaService
    {
        Task<List<MaquinaMostrarDTO>> ObtenerTodosAsync();
        Task<MaquinaMostrarDTO?> ObtenerPorIdAsync(int id);
        Task<int> AgregarAsync(MaquinaCreaActualizaDTO maquinaDto);
        Task ActualizarAsync(int id, MaquinaCreaActualizaDTO maquinaDto);
        Task EliminarAsync(int id);
    }
}
