using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IHistoricoSueldoService
    {
        Task<List<HistoricoSueldoMostrarDTO>> ObtenerTodosAsync(int? idProfesor);
        Task<int> RegistrarAsync(HistoricoSueldoCreaDTO dto);
    }
}
