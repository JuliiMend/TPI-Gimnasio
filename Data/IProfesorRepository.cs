using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public interface IProfesorRepository
    {
        List<Profesor> ObtenerTodos();
        Profesor? ObtenerPorId(int id);
        void Agregar(Profesor profesor);
        void Actualizar(Profesor profesor);
        void Eliminar(int id);
    }
}