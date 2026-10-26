using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public interface IProfesorRepository
    {
        Task<List<Profesor>> ObtenerTodosAsync();
        Task<Profesor?> ObtenerPorIdAsync(int id);
        Task<Profesor?> ObtenerPorUsuarioIdAsync(int usuarioId);
        Task AgregarAsync(Profesor profesor);
        Task ActualizarAsync(Profesor profesor);
        Task<bool> ExisteDniAsync(string dni, int? exceptoId = null);
        Task EliminarAsync(int id);
    }
}