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
        List<SocioMostrarDTO> ObtenerTodos(SocioCriteriaDTO criterios);
        SocioMostrarDTO? ObtenerPorId(int id);
        void Agregar(SocioCreaActualizaDTO socioDto);
        void Actualizar(int id, SocioCreaActualizaDTO socioDto);
        void Eliminar(int id);
    }
}
