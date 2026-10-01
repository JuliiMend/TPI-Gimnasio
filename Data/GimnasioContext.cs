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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Claves de la herencia Persona
            modelBuilder.Entity<Profesor>().HasKey(p => p.PersonaId);
            modelBuilder.Entity<Socio>().HasKey(s => s.PersonaId);

            // Claves del resto de las entidades
            modelBuilder.Entity<Turno>().HasKey(t => t.IdTurno);
            modelBuilder.Entity<Plan>().HasKey(p => p.PlanId);
            modelBuilder.Entity<Cuota>().HasKey(c => c.CuotaId);
            modelBuilder.Entity<DetalleCuota>().HasKey(d => d.DetalleCuotaId);

            modelBuilder.Entity<Plan>().Property(p => p.Precio).HasPrecision(18, 2); 
            modelBuilder.Entity<Cuota>().Property(c => c.Valor).HasPrecision(18, 2);
            modelBuilder.Entity<DetalleCuota>().Property(d => d.Monto).HasPrecision(18, 2);
            modelBuilder.Entity<DetalleCuota>().Property(d => d.Subtotal).HasPrecision(18, 2);


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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // tenía la cadena de conexión de SQL Server hardcodeada para evitar conflictos.
            // Hay que verificar que todos tengamos appsettings.json local bien configurado para que el contexto se inyecte correctamente desde el Program.cs
            // if (!optionsBuilder.IsConfigured)
            // {
            //     optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MSSQL-TPIGim;Trusted_Connection=True;...");
            // }
        }
    }
}

