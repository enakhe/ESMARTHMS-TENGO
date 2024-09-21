using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Account.BankAccount
{
    public partial class EditBankAccountForm : Form
    {
        private readonly SystemSetupController _systemSetupController;
        private readonly string _id;
        public EditBankAccountForm(SystemSetupController systemSetupController, string id)
        {
            _id = id;
            _systemSetupController = systemSetupController;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                Domain.Entities.BankAccount bankAccount = _systemSetupController.GetBankAccountById(_id);
                if (bankAccount != null)
                {
                    txtAccName.Text = bankAccount.BankAccName;
                    txtBankAccNo.Text = bankAccount.BankAccNo;
                    txtBankName.Text = bankAccount.BankName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtAccName.Text, txtBankAccNo.Text, txtBankName.Text);
                if (isNull)
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    Domain.Entities.BankAccount bankAccount = _systemSetupController.GetBankAccountById(_id);
                    if (bankAccount != null)
                    {
                        bankAccount.BankAccName = txtAccName.Text.ToUpper();
                        bankAccount.BankName = txtBankName.Text.ToUpper();
                        bankAccount.BankAccNo = txtBankAccNo.Text;
                        bankAccount.DateModified = DateTime.Now;

                        _systemSetupController.UpdateBankAccount(bankAccount);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void txtBankAccNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
