using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Sessions;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Account.BankAccount
{
    public partial class AddBankAccountForm : Form
    {
        private readonly SystemSetupController _systemSetupController;
        private readonly ApplicationUserController _userController;
        public AddBankAccountForm(SystemSetupController systemSetupController, ApplicationUserController userController)
        {
            _systemSetupController = systemSetupController;
            InitializeComponent();
            _userController = userController;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtAccName.Text, txtBankAccNo.Text, txtBankName.Text);
            if (isNull)
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                Domain.Entities.BankAccount bankAccount = new Domain.Entities.BankAccount()
                {
                    Id = Guid.NewGuid().ToString(),
                    BankAccName = txtAccName.Text.ToUpper(),
                    BankName = txtBankName.Text.ToUpper(),
                    BankAccNo = txtBankAccNo.Text,
                    CreatedBy = AuthSession.CurrentUser.Id,
                    ApplicationUser = _userController.GetApplicationUserById(AuthSession.CurrentUser.Id),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };
                _systemSetupController.AddBankAccount(bankAccount);
                this.DialogResult = DialogResult.OK;
                this.Close();
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
