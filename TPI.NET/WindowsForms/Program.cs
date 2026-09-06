using Application.Services; // Referencia a los servicios (La auth)
using Data; // Referencia al proyecto de acceso a datos (Los "DAO")
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace UI.Desktop 
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
            var connectionString = "Server=localhost\\SQLEXPRESS;Database=MSSQL-TPIGim;Trusted_Connection=True;TrustServerCertificate=True;";
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
               services.AddTransient<PlanListaForm>();
               //services.AddTransient<PlanDetalle>();


            //Declaraci{on de los servicios y repositorios para los formularios que se van a utilizar
                
                // Para los Planes
                services.AddTransient<IPlanRepository, PlanRepository>();
                services.AddTransient<IPlanService, PlanService>();
                services.AddTransient<PlanDetalle>();


        }
    }
}