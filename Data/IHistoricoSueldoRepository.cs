using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IHistoricoSueldoRepository
    {
        Task<List<HistoricoSueldo>> ObtenerTodosAsync(int? idProfesor);
        Task<HistoricoSueldo?> ObtenerPorIdAsync(int id);
        Task<bool> ExisteAsync(int idProfesor, DateTime fechaDesde);
        Task AgregarAsync(HistoricoSueldo historicoSueldo);
    }
}
