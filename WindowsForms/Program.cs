using Application.Services; // Referencia a los servicios (La auth)
using Data; // Referencia al proyecto de acceso a datos (Los "DAO")
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using WindowsFormsApp;

namespace WindowsFormsApp
{
    internal static class Program
    {
        // Exponemos el ServiceProvider para que los formularios puedan pedir dependencias
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            var loginForm = ServiceProvider.GetRequiredService<LoginForm>();

            System.Windows.Forms.Application.Run(loginForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Configuracion del DbContext
            var connectionString = "Server=localhost\\SQLEXPRESS;Database=MSSQL-TPIGim;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
            services.AddDbContext<GimnasioContext>(options =>
            options.UseSqlServer(connectionString),
            ServiceLifetime.Transient);

            // B. Registrar Repositorios (Data Access)
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();


            // Registro de las reglas de negocio a verificar en el login
            services.AddTransient<IAuthService, AuthService>();


            // Registrar los Formularios - Generales
            services.AddTransient<LoginForm>();
            services.AddTransient<Home>();

            // Formularios para Plan
            services.AddTransient<PlanLista>();
            //services.AddTransient<PlanDetalle>();


            // Formularios para Turno
            services.AddTransient<TurnoLista>();
            services.AddTransient<TurnoDetalle>();

            //Declaraci{on de los servicios y repositorios para los formularios que se van a utilizar

            // Para los Planes
            services.AddTransient<IPlanRepository, PlanRepository>();
            services.AddTransient<IPlanService, PlanService>();
            services.AddTransient<PlanDetalle>();


            // Para los Turnos
            services.AddTransient<ITurnoRepository, TurnoRepository>();
            services.AddTransient<ITurnoService, TurnoService>();


            // Para los Profesores
            services.AddTransient<IProfesorRepository, ProfesorRepository>();
            services.AddTransient<IProfesorService, ProfesorService>();
            services.AddTransient<ProfesorLista>();
            services.AddTransient<ProfesorDetalle>();
            

            // Para los Socios
            services.AddTransient<ISocioRepository, SocioRepository>();
            services.AddTransient<ISocioService, SocioService>();
            services.AddTransient<SocioLista>();
            services.AddTransient<SocioDetalle>();

        }
    }
}