using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Infrastructure.Services;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.License;
using ESMART_HMS.Presentation.Forms.Maintenance.CardMaintenance.Cards;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms
{
    public partial class LicenseForm : Form
    {
        private readonly LicenseController _licenseController;
        private readonly ConfigurationController _configurationController;
        public LicenseForm(LicenseController licenseController, ConfigurationController configurationController)
        {
            _licenseController = licenseController;
            _configurationController = configurationController;
            InitializeComponent();
        }

        private void txtProductKey_TextChanged(object sender, EventArgs e)
        {
            string text = txtProductKey.Text.Replace("-", "");

            if (text.Length > 24)
            {
                text = text.Substring(0, 24);
            }

            var formattedText = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                if (i > 0 && i % 6 == 0)
                {
                    formattedText += "-";
                }
                formattedText += text[i];
            }

            txtProductKey.TextChanged -= txtProductKey_TextChanged;
            txtProductKey.Text = formattedText;
            txtProductKey.SelectionStart = txtProductKey.Text.Length;
            txtProductKey.TextChanged += txtProductKey_TextChanged;
        }

        private void freeTrial_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            var hotelName = "Free Trial" + random.Next(100000, 200000);
            string productKey = LicenceHelper.GenerateProductKey(hotelName, DateTime.Now.AddDays(7));
            if (productKey != null)
            {
                txtHotelName.Text = "Free Trial";
                txtProductKey.Text = productKey;

                txtHotelName.ReadOnly = true;
                txtProductKey.ReadOnly = true;
            }
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            Configuration configuration = _configurationController.GetConfigurationValue("Trial Mode");
            if (configuration != null)
            {
                if (configuration.Value.ToString() == "True")
                {
                    freeTrial.Enabled = false;
                }
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtHotelName.Text, txtProductKey.Text);
            if (isNull)
            {
                MessageBox.Show("Invalid product key and hotel name", "Please add all fields", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            }
            else
            {
                if (txtProductKey.Text.Length != 27)
                {
                    MessageBox.Show("Invalid product key", "Invalid product key", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                }
                else
                {
                    bool isValid = LicenceHelper.ValidateProductKey(txtHotelName.Text, txtProductKey.Text);
                    if (isValid)
                    {
                        MessageBox.Show("Product Key was successfully validated", "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        var services = new ServiceCollection();
                        DependencyInjection.ConfigureServices(services);
                        var serviceProvider = services.BuildServiceProvider();

                        InitializeDatabaseForm initializeDatabaseForm = serviceProvider.GetRequiredService<InitializeDatabaseForm>();
                        if (initializeDatabaseForm.ShowDialog() == DialogResult.OK)
                        {
                            DateTime expirationDate;
                            string expDatStr = LicenceHelper.GetExpirationDate(txtProductKey.Text);
                            DateTime.TryParseExact(expDatStr, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out expirationDate);

                            if (txtHotelName.Text != "Free Trial")
                            {
                                LicenseInfo licenseInfo = new LicenseInfo()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    ProductKey = txtProductKey.Text,
                                    ExpiryDate = expirationDate,
                                    HotelName = txtHotelName.Text,
                                    DateCreated = DateTime.Now,
                                    DateModified = DateTime.Now,
                                };
                                _licenseController.AddLicense(licenseInfo);
                                SecureFileHelper.SaveSecureFile(txtHotelName.Text, txtProductKey.Text, expirationDate);
                                DatabaseService.SeedLicensedUser(licenseInfo.HotelName, licenseInfo.ProductKey.Replace("-", "").Substring(0, 7));

                                //AuthCard authCard = serviceProvider.GetRequiredService<AuthCard>();
                                //if (authCard.ShowDialog() == DialogResult.OK)
                                //{
                                //}
                                    this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                _configurationController.SetConfigurationValue("Trial Mode", "True");
                                SecureFileHelper.SaveSecureFile(txtHotelName.Text, txtProductKey.Text, expirationDate);
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid product key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
