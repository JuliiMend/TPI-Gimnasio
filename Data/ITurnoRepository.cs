using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public interface ITurnoRepository
    {
        List<Turno> ObtenerTodos();
        Turno? ObtenerPorId(int id);
        void Agregar(Turno turno);
        void Actualizar(Turno turno);
        void Eliminar(int id);
    }
}
