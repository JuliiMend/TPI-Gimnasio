using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Domain.Model
{
    public class Socio : Persona
    {
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public int IdPlan { get; set; }
        public Plan? Plan { get; set; }
    }
}