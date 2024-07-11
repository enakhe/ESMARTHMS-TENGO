using ESMART_HMS.Infrastructure.Services;
using ESMART_HMS.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ESMART_HMS
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            DatabaseService.InitializeDatabase();
            DatabaseService.SeedData();

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
            System.Windows.Forms.Application.Run(loginForm);
        }
    }
}
