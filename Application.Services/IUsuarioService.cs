using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Application.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioMostrarDTO>> ObtenerTodosAsync();
        Task<UsuarioMostrarDTO?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(UsuarioCreaActualizaDTO dto);
        Task ActualizarAsync(int id, UsuarioCreaActualizaDTO dto);
        Task EliminarAsync(int id);
    }
}