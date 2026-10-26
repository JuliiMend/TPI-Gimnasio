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
        Task<List<SocioMostrarDTO>> ObtenerTodosAsync(SocioCriteriaDTO? criterios);
        Task<PaginaDTO<SocioMostrarDTO>> ObtenerPaginadoAsync(SocioCriteriaDTO? criterios, int numeroPagina, int tamanioPagina);
        Task<SocioMostrarDTO?> ObtenerPorIdAsync(int id);
        Task<SocioMostrarDTO?> ObtenerPorUsuarioAsync(int usuarioId);
        Task <int> AgregarAsync(SocioCreaActualizaDTO socioDto);
        Task ActualizarAsync(int id, SocioCreaActualizaDTO socioDto);
        Task EliminarAsync(int id);
    }
}