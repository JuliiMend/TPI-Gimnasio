using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public interface IPlanRepository
    {
        List<Plan> ObtenerTodos();
        Plan? ObtenerPorId(int id);
    }
}