using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class GimnasioContext : DbContext
    {
        public GimnasioContext(DbContextOptions<GimnasioContext> options) : base(options) { }

        public DbSet<Socio> Socios { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Turno> Turnos { get; set; }

    }
}