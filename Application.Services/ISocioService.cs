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
        List<SocioDTO> ObtenerTodos(SocioCriteriaDTO criterios);
        SocioDTO? ObtenerPorId(int id);
        void Agregar(SocioDTO socioDto);
        void Actualizar(int id, SocioDTO socioDto);
        void Eliminar(int id);
    }
}