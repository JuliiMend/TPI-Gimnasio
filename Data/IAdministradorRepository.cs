using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public interface IAdministradorRepository
    {
        Task<List<Administrador>> ObtenerTodosAsync();
        Task<Administrador?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Administrador administrador);
        Task ActualizarAsync(Administrador administrador);
        Task<bool> ExisteDniAsync(string dni, int? exceptoId = null);
        Task EliminarAsync(int id);
    }
}