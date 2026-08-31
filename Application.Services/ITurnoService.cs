using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Application.Services
{
    public interface ITurnoService
    {
        List<TurnoDTO> ObtenerTodos();
        TurnoDTO? ObtenerPorId(int id);
        void Agregar(TurnoCreaActualizaDTO turnoDto);
        void Actualizar(int id, TurnoCreaActualizaDTO turnoDto);
        void Eliminar(int id);
    }
}