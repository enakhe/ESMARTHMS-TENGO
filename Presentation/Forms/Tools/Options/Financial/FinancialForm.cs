using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Tools.Option.Financial
{
    public partial class FinancialForm : Form
    {
        private readonly ConfigurationController _configurationController;
        public FinancialForm(ConfigurationController configurationController)
        {
            InitializeComponent();
            _configurationController = configurationController;
        }

        private void FinancialForm_Load(object sender, System.EventArgs e)
        {
            LoadVAT();
            LoadDiscount();
        }

        private void LoadVAT()
        {
            Configuration configuration = _configurationController.GetConfigurationValue("VAT");
            if (configuration == null)
            {
                txtVAT.Text = "0.00";
            }
            else
            {
                txtVAT.Text = configuration.Value.ToString();
            }
        }

        private void LoadDiscount()
        {
            Configuration configuration = _configurationController.GetConfigurationValue("Discount");
            if (configuration == null)
            {
                txtDiscount.Text = "0.00";
            }
            else
            {
                txtDiscount.Text = configuration.Value.ToString();
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtVAT.Text, txtDiscount.Text);
            if (isNull)
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                _configurationController.SetConfigurationValue("VAT", txtVAT.Text);
                _configurationController.SetConfigurationValue("Discount", txtDiscount.Text);

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
