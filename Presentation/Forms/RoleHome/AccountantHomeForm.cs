using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESMART_HMS.Presentation.Forms.Account.BankAccount;
using ESMART_HMS.Presentation.Forms.Guests;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Configuration;
using ESMART_HMS.Presentation.Forms.Account.ChartOfAccount;

namespace ESMART_HMS.Presentation.Forms.RoleHome
{
    public partial class AccountantHomeForm : Form
    {
        BankAccountForm bankAccountForm;
        ChartAccountForm chartOfAccountForm;

        private readonly LicenseController _licenseController;
        private readonly ConfigurationController _configurationController;

        public AccountantHomeForm(LicenseController licenseController, ConfigurationController configurationController)
        {
            _licenseController = licenseController;
            _configurationController = configurationController;
            InitializeComponent();
        }

        private void AccountantHomeForm_Load(object sender, EventArgs e)
        {
            MdiClient client = this.Controls.OfType<MdiClient>().FirstOrDefault();
            if (client != null)
            {
                client.BackColor = Color.White;
            }

            LicenseInfo licenseInfo = _licenseController.GetLicenseInfo();
            Configuration configuration = _configurationController.GetConfigurationValue("Trial Mode");

            if (licenseInfo != null)
            {
                if (licenseInfo.HotelName != null)
                {
                    this.Text = $"ESMART Hotel Management Software ({licenseInfo.HotelName})";
                }
            }
            else if (configuration != null)
            {
                if (configuration.Value.ToString() == "True")
                {
                    this.Text = $"ESMART Hotel Management Software (Free Trial)";
                }
            }

            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "background.jpg");

            try
            {
                this.BackgroundImage = new Bitmap(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bankAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bankAccountForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                bankAccountForm = serviceProvider.GetRequiredService<BankAccountForm>();
                bankAccountForm.FormClosed += BankAccountForm_FormClosed;
                bankAccountForm.ShowDialog();
            }
            else
            {
                bankAccountForm.Activate();
            }

        }

        private void BankAccountForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            bankAccountForm = null;
        }

        private void chartsOfAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chartOfAccountForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                chartOfAccountForm = serviceProvider.GetRequiredService<ChartAccountForm>();
                chartOfAccountForm.FormClosed += ChartOfAccountForm_FormClosed;
                chartOfAccountForm.ShowDialog();
            }
            else
            {
                chartOfAccountForm.Activate();
            }
        }

        private void ChartOfAccountForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            chartOfAccountForm = null;
        }
    }
}
