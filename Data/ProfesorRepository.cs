using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;


namespace Data
{
    public class ProfesorRepository : IProfesorRepository
    {
        public List<Profesor> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public Profesor? ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Profesor profesor)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(Profesor profesor)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}