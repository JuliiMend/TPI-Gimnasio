using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Application.Services
{
    public interface ISocioService
    {
        Task<List<SocioMostrarDTO>> ObtenerTodosAsync(SocioCriteriaDTO criterios);
        Task<SocioMostrarDTO?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(SocioCreaActualizaDTO socioDto);
        Task ActualizarAsync(int id, SocioCreaActualizaDTO socioDto);
        Task EliminarAsync(int id);
    }
}