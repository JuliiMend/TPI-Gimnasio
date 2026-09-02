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
        // 1.Constructor actual
        public GimnasioContext(DbContextOptions<GimnasioContext> options) : base(options)
        {
        }

        // Tablas actuales
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Turno> Turnos { get; set; }

        // 3. ACA PEGAS EL METODO NUEVO:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Claves de la herencia Persona
            modelBuilder.Entity<Profesor>().HasKey(p => p.PersonaId);
            modelBuilder.Entity<Socio>().HasKey(s => s.PersonaId);

            // Claves del resto de las entidades
            modelBuilder.Entity<Turno>().HasKey(t => t.IdTurno); 
            modelBuilder.Entity<Plan>().HasKey(p => p.PlanId); 
            modelBuilder.Entity<Plan>().Property(p => p.Precio).HasPrecision(18, 2);
        }
    }
}

