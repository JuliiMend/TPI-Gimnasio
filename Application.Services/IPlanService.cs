using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPlanService
    {
        Task<List<PlanMostrarDTO>> ObtenerTodosAsync();
        Task<PlanMostrarDTO?> ObtenerPorIdAsync(int id);
        Task<int> CrearAsync(PlanCreaActualizaDTO planDto);
        Task ActualizarAsync(int id, PlanCreaActualizaDTO planDto);
        Task EliminarAsync(int id);
    }
}