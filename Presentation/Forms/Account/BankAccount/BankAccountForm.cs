using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class BankAccountForm : Form
    {
        private readonly SystemSetupController _sytemSetupController;

        public BankAccountForm(SystemSetupController sytemSetupController)
        {
            _sytemSetupController = sytemSetupController;
            InitializeComponent();
            tabControl1.Appearance = TabAppearance.Normal;
        }

        private void InitializeBankAccountTab(TabPage tabPage)
        {
            if (tabPage != null)
            {
                if (tabPage.Text == "Bank Account")
                {
                    List<BankAccountViewModel> allAccounts = _sytemSetupController.GetAllBankAccount();
                    if (allAccounts != null)
                    {
                        foreach (BankAccountViewModel account in allAccounts)
                        {
                            account.DateCreated = FormHelper.FormatDateTimeWithSuffix(account.DateCreated);
                            account.DateModified = FormHelper.FormatDateTimeWithSuffix(account.DateModified);
                        }
                        dgvAccount.DataSource = allAccounts;
                    }
                }
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tabPage = tabControl.TabPages[e.Index];

            Rectangle tabRect = tabControl.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);

            Color backColor;

            if (tabPage.Text == "Bank Account")
            {
                backColor = ColorTranslator.FromHtml("#80AF81");
            }
            else
            {
                backColor = e.State == DrawItemState.Selected ? Color.LightBlue : Color.LightGray;
            }

            using (Brush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }

            Font font = new Font("Segoe UI", 13, FontStyle.Bold);

            TextRenderer.DrawText(e.Graphics, tabPage.Text, font, tabRect, tabPage.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void btnAddBank_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddBankAccountForm addBankAccountForm = serviceProvider.GetRequiredService<AddBankAccountForm>();
            if (addBankAccountForm.ShowDialog() == DialogResult.OK)
            {
                InitializeBankAccountTab(bankAccount);
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccount.SelectedRows.Count > 0)
                {
                    var row = dgvAccount.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (EditBankAccountForm editBankAccountForm = new EditBankAccountForm(_sytemSetupController, id))
                    {
                        if (editBankAccountForm.ShowDialog() == DialogResult.OK)
                        {
                            InitializeBankAccountTab(bankAccount);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an account to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccount.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to add the selected accounts to the recycle?\nIts record including all entries tagged to such account will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvAccount.SelectedRows)
                        {
                            string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                            _sytemSetupController.DeleteBankAccount(id);
                        }
                        InitializeBankAccountTab(bankAccount);
                        MessageBox.Show("Successfully added account information to recycle", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an account to recycle.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void BankAccountForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eSMART_HMSDBDataSet.BankAccount' table. You can move, or remove it, as needed.
            this.bankAccountTableAdapter.Fill(this.eSMART_HMSDBDataSet.BankAccount);

        }
    }
}
