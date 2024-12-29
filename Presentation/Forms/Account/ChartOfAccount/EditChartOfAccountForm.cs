using DocumentFormat.OpenXml.Wordprocessing;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
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

namespace ESMART_HMS.Presentation.Forms.Account.BankAccount
{
    public partial class EditChartOfAccountForm : Form
    {
        private readonly AccountController _accountController;
        private readonly string _id;
        public EditChartOfAccountForm(string id, AccountController accountController)
        {
            _id = id;
            _accountController = accountController;
            InitializeComponent();
            LoadData();
            this.Activated += EditChartOfAccountForm_Activated;
        }

        public void LoadData()
        {
            try
            {
                Domain.Entities.ChartOfAccount chartOfAccount = _accountController.GetChartOfAccountById(_id);
                if(chartOfAccount != null)
                {
                    txtAccCode.Text = chartOfAccount.AccountCode;
                    txtAccName.Text = chartOfAccount.AccountName;
                    txtAccGroup.Text = chartOfAccount.AccountGroup;
                    txtAccType.Text = chartOfAccount.AccountType;
                    txtRollTo.Text = chartOfAccount.RollTo;
                    checckRollBalance.Checked = (bool)chartOfAccount.RollBalance;
                    checkCashFlowAcc.Checked = (bool)chartOfAccount.CashflowAccount;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
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
            if (isNull == false)
            {
                Domain.Entities.ChartOfAccount chartOfAccount = _accountController.GetChartOfAccountById(_id);

                if (chartOfAccount != null)
                {
                    chartOfAccount.AccountCode = txtAccCode.Text;
                    chartOfAccount.AccountName = txtAccName.Text;
                    chartOfAccount.AccountGroup = txtAccGroup.Text;
                    chartOfAccount.AccountType = txtAccType.Text;
                    chartOfAccount.IsActive = true;
                    chartOfAccount.RollTo = txtRollTo.Text;
                    chartOfAccount.RollBalance = checckRollBalance.Checked;
                    chartOfAccount.CashflowAccount = checkCashFlowAcc.Checked;
                    chartOfAccount.DateModified = DateTime.Now;
                }
                
                _accountController.EditChartOfAccount(chartOfAccount);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void EditChartOfAccountForm_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
