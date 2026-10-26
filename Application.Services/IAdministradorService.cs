using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Application.Services
{
    public interface IAdministradorService
    {
        Task<List<AdministradorMostrarDTO>> ObtenerTodosAsync();
        Task<AdministradorMostrarDTO?> ObtenerPorIdAsync(int id);
        Task<int> AgregarAsync(AdministradorCreaActualizaDTO administradorDto);
        Task ActualizarAsync(int id, AdministradorCreaActualizaDTO administradorDto);
        Task EliminarAsync(int id, int? idUsuarioActual);
    }
}