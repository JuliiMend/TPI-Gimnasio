using Data;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class SocioRepository : ISocioRepository
    {
        public List<Socio> ObtenerTodos(SocioCriteria criterios)
        {
            throw new NotImplementedException();
        }

        public Socio? ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Socio socio)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(Socio socio)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}