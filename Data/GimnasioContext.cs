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

        public GimnasioContext()
        {
        }

        public GimnasioContext(DbContextOptions<GimnasioContext> options) : base(options)
        {
        }

        // Tablas actuales
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<DetalleCuota> DetallesCuota { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Clase> Clases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Claves de la herencia Persona
            modelBuilder.Entity<Profesor>().HasKey(p => p.PersonaId);
            modelBuilder.Entity<Socio>().HasKey(s => s.PersonaId);
            modelBuilder.Entity<Administrador>().HasKey(a => a.PersonaId);

            // Claves del resto de las entidades
            modelBuilder.Entity<Turno>().HasKey(t => t.IdTurno);
            modelBuilder.Entity<Plan>().HasKey(p => p.PlanId);
            modelBuilder.Entity<Cuota>().HasKey(c => c.CuotaId);
            modelBuilder.Entity<DetalleCuota>().HasKey(d => d.DetalleCuotaId);

            modelBuilder.Entity<Plan>().Property(p => p.Precio).HasPrecision(18, 2); 
            modelBuilder.Entity<Cuota>().Property(c => c.Valor).HasPrecision(18, 2);
            modelBuilder.Entity<DetalleCuota>().Property(d => d.Monto).HasPrecision(18, 2);
            modelBuilder.Entity<DetalleCuota>().Property(d => d.Subtotal).HasPrecision(18, 2);

            modelBuilder.Entity<Maquina>().HasKey(m => m.IdMaquina);
            modelBuilder.Entity<Material>().HasKey(m => m.IdMaterial);
            modelBuilder.Entity<Actividad>().HasKey(a => a.IdActividad);
            modelBuilder.Entity<Clase>().HasKey(c => c.IdClase);


            // Claves de Usuario
            modelBuilder.Entity<Usuario>().HasKey(u => u.UsuarioId);
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Username).IsUnique();

            // Relación Persona (Socio/Profesor) -> Usuario
            modelBuilder.Entity<Socio>()
                .HasOne(s => s.Usuario)
                .WithMany() 
                .HasForeignKey(s => s.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Profesor>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Administrador>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // relacion plan actividad (un plan incluye varias actividades y viceversa)
            modelBuilder.Entity<Plan>()
                .HasMany(p => p.Actividades)
                .WithMany(a => a.Planes)
                .UsingEntity(j => j.ToTable("PlanActividades"));

            // relaciones de clase: actividad, profesor a cargo y turno
            modelBuilder.Entity<Clase>()
                .HasOne(c => c.Actividad)
                .WithMany()
                .HasForeignKey(c => c.IdActividad)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Clase>()
                .HasOne(c => c.Profesor)
                .WithMany()
                .HasForeignKey(c => c.IdProfesor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Clase>()
                .HasOne(c => c.Turno)
                .WithMany()
                .HasForeignKey(c => c.IdTurno)
                .OnDelete(DeleteBehavior.Restrict);


            // relación real Socio -> Plan usando la columna IdPlan
            modelBuilder.Entity<Socio>()
                    .HasOne(s => s.Plan)
                    .WithMany()
                    .HasForeignKey(s => s.IdPlan)
                    .OnDelete(DeleteBehavior.Restrict);

            // relacion socio cuota
            modelBuilder.Entity<Cuota>()
                .HasOne(c => c.Socio)
                .WithMany(s => s.Cuotas)
                .HasForeignKey(c => c.SocioId)
                .OnDelete(DeleteBehavior.Restrict);

            // relacion cuota detallecuota
            modelBuilder.Entity<Cuota>()
                .HasMany(c => c.Detalles)
                .WithOne(d => d.Cuota)
                .HasForeignKey(d => d.CuotaId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}

