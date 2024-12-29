using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers.Account;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.Account.BankAccount;
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

namespace ESMART_HMS.Presentation.Forms.Account.ChartOfAccount
{
    public partial class ChartAccountForm : Form
    {
        private readonly AccountController _accountController;
        public ChartAccountForm(AccountController accountController)
        {
            _accountController = accountController;
            InitializeComponent();
        }


        private void ChartAccountForm_Load(object sender, EventArgs e)
        {
            InitializeBankAccountTab();
        }

        private void InitializeBankAccountTab()
        {
            List<ChartOfAccountViewModel> allChartOfAccount = _accountController.GetAllChartOfAccount();
            if (allChartOfAccount != null)
            {
                dgvAccount.DataSource = allChartOfAccount;
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tabPage = tabControl.TabPages[e.Index];

            Rectangle tabRect = tabControl.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);

            Color backColor;

            if (tabPage.Text == "Chart of Account")
            {
                backColor = ColorTranslator.FromHtml("#00739f");
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

            AddChartOfAccountForm addChartOfAccountForm = serviceProvider.GetRequiredService<AddChartOfAccountForm>();
            if (addChartOfAccountForm.ShowDialog() == DialogResult.OK)
            {
                InitializeBankAccountTab();
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

                    if(id == null)
                    {
                        MessageBox.Show("Could not get account id", "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    using (EditChartOfAccountForm editChartOfAccountForm = new EditChartOfAccountForm(id, _accountController))
                    {
                        if (editChartOfAccountForm.ShowDialog() == DialogResult.OK)
                        {
                            InitializeBankAccountTab();
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
                            Domain.Entities.ChartOfAccount chartOfAccount =  _accountController.GetChartOfAccountById(id);
                            if (id == null)
                            {
                                MessageBox.Show("Could not get account id", "Exception Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }

                            if (chartOfAccount != null)
                            {
                                chartOfAccount.IsTrashed = true;
                                chartOfAccount.DateModified = DateTime.Now;
                            }
                            _accountController.EditChartOfAccount(chartOfAccount);
                        }
                        InitializeBankAccountTab();
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
    }
}
