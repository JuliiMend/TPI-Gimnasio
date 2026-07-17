using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;


namespace Data
{
    public interface ISocioRepository
    {
        List<Socio> ObtenerTodos(SocioCriteria criterios);
        Socio? ObtenerPorId(int id);
        void Agregar(Socio socio);
        void Actualizar(Socio socio);
        void Eliminar(int id);
    }
}