using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Application.Services
{
    public interface IProfesorService
    {
        Task<List<ProfesorDTO>> ObtenerTodosAsync();
        Task<ProfesorDTO?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(ProfesorCreaActualizaDTO profesorDto);
        Task ActualizarAsync(int id, ProfesorCreaActualizaDTO profesorDto);
        Task EliminarAsync(int id);
    }
}