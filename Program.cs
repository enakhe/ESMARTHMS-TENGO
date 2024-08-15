using ESMART_HMS.Infrastructure.Services;
using ESMART_HMS.Presentation.Forms;
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

            DatabaseService.InitializeDatabase();
            DatabaseService.SeedData();

            System.Windows.Forms.Application.Run(new SplashScreenForm());
        }
    }
}
