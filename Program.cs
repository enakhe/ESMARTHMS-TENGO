using ESMART_HMS.Application;
using ESMART_HMS.Domain;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Infrastructure;
using ESMART_HMS.Presentation;
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

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
            System.Windows.Forms.Application.Run(loginForm);
        }
    }
}
