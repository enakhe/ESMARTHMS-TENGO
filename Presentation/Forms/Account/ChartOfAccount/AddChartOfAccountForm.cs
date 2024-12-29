using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Account;
using ESMART_HMS.Presentation.Sessions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Account.ChartOfAccount
{
    public partial class AddChartOfAccountForm : Form
    {
        private readonly ApplicationUserController _userController;
        private readonly AccountController _accountController;

        public AddChartOfAccountForm(ApplicationUserController userController, AccountController accountController)
        {
            _userController = userController;
            _accountController = accountController;
            InitializeComponent();
        }

        private void AddChartOfAccountForm_Load(object sender, EventArgs e)
        {

        }

        private void txtAccCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRollTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtAccCode.Text, txtAccName.Text, txtAccGroup.Text, txtAccType.Text);
            if(isNull == false)
            {
                Domain.Entities.ChartOfAccount chartOfAccount = new Domain.Entities.ChartOfAccount()
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountCode = txtAccCode.Text,
                    AccountName = txtAccName.Text.ToUpper(),
                    AccountGroup = txtAccGroup.Text,
                    AccountType = txtAccType.Text,
                    IsActive = true,
                    IsTrashed = false,
                    CreatedBy = AuthSession.CurrentUser.Id,
                    RollTo = txtRollTo.Text,
                    RollBalance = checckRollBalance.Checked,
                    CashflowAccount = checkCashFlowAcc.Checked,
                    ApplicationUser = _userController.GetApplicationUserById(AuthSession.CurrentUser.Id),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };
                _accountController.AddChartOfAccount(chartOfAccount);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
