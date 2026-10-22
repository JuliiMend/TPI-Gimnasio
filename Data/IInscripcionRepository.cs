using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IInscripcionRepository
    {
        Task<List<Inscripcion>> ObtenerTodosAsync(int? idClase);
        Task<Inscripcion?> ObtenerPorIdAsync(int id);
        Task<int> ContarPorClaseAsync(int idClase);
        Task<bool> ExisteAsync(int idSocio, int idClase);
        Task AgregarAsync(Inscripcion inscripcion);
        Task EliminarAsync(int id);
    }
}
