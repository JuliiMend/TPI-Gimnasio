using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;


namespace Data
{
    public class PlanRepository : IPlanRepository
    {
        public List<Plan> ObtenerTodos()
        {
            return DatosEnMemoria.Planes;
        }

        public Plan? ObtenerPorId(int id)
        {
            return DatosEnMemoria.Planes.FirstOrDefault(p => p.IdPlan == id);
        }
    }
}