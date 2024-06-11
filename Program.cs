using ESMART_HMS.Forms;
using ESMART_HMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DatabaseHelper.InitializeDatabase();
            DatabaseHelper.AddSampleUser();

            AuthService authService = new AuthService();

            Application.Run(new LoginForm(authService));

            //Application.Run(new Home());
        }
    }
}
