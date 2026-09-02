using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IPlanRepository
    {
        Task<List<Plan>> ObtenerTodosAsync();
        Task<Plan?> ObtenerPorIdAsync(int id);
    }
}