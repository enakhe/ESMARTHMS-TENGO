using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class SplashScreenForm : Form
    {
        private Timer timer;
        private readonly LicenseController _licenseController;

        public SplashScreenForm(LicenseController licenseController)
        {
            _licenseController = licenseController;
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

            string hotelName, productKey;
            DateTime expirationDate;

            bool isLoaded = SecureFileHelper.TryLoadProductKey(out hotelName, out productKey, out expirationDate);

            if (isLoaded)
            {
                bool isValid = LicenceHelper.ValidateProductKey(hotelName, productKey);
                if (isValid)
                {
                    if (expirationDate > DateTime.Now)
                    {
                        var loginForm = serviceProvider.GetRequiredService<LoginForm>();
                        var loginResult = loginForm.ShowDialog();
                        if (loginResult == DialogResult.OK)
                        {
                            var homeForm = serviceProvider.GetRequiredService<Home>();
                            homeForm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("License has expired.", "License Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        var licence = serviceProvider.GetRequiredService<LicenseForm>();
                        var result = licence.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
                            var loginResult = loginForm.ShowDialog();
                            if (loginResult == DialogResult.OK)
                            {
                                var homeForm = serviceProvider.GetRequiredService<Home>();
                                homeForm.ShowDialog();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid product key.", "License Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var licence = serviceProvider.GetRequiredService<LicenseForm>();
                    var result = licence.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        var loginForm = serviceProvider.GetRequiredService<LoginForm>();
                        var loginResult = loginForm.ShowDialog();
                        if (loginResult == DialogResult.OK)
                        {
                            var homeForm = serviceProvider.GetRequiredService<Home>();
                            homeForm.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No valid license found. Please enter a valid product key.", "License Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var licence = serviceProvider.GetRequiredService<LicenseForm>();
                var result = licence.ShowDialog();

                if (result == DialogResult.OK)
                {
                    var loginForm = serviceProvider.GetRequiredService<LoginForm>();
                    var loginResult = loginForm.ShowDialog();
                    if (loginResult == DialogResult.OK)
                    {
                        var homeForm = serviceProvider.GetRequiredService<Home>();
                        homeForm.ShowDialog();
                    }
                }
            }
            this.Close();
        }
    }
}
