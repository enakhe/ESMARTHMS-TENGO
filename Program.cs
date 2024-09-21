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

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            var splashScreenForm = serviceProvider.GetRequiredService<SplashScreenForm>();
            DatabaseService.InitializeDatabase();
            DatabaseService.SeedData();

            System.Windows.Forms.Application.Run(splashScreenForm);
        }
    }
}
