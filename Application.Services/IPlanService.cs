using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPlanService
    {
        Task<List<PlanDTO>> ObtenerTodosAsync();
        Task<PlanDTO?> ObtenerPorIdAsync(int id);
    }
}