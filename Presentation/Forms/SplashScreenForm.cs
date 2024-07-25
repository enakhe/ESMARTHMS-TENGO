using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class SplashScreenForm : Form
    {
        private Timer timer;
        public SplashScreenForm()
        {
            InitializeComponent();
            Shown += SplashScreenForm_Shown;
        }

        private async void SplashScreenForm_Shown(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            this.Hide();

            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            using (var loginForm = serviceProvider.GetRequiredService<LoginForm>())
            {
                loginForm.ShowDialog();
            }

            this.Close();
        }
    }
}
