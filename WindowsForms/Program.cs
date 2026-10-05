using API.Clients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
            Application.Run(loginForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {

            var authService = new AuthService();

            AuthServiceProvider.Register(authService);

            services.AddSingleton<IAuthService>(authService);


            services.AddTransient<LoginForm>();
            services.AddTransient<Home>();

        }
    }
}