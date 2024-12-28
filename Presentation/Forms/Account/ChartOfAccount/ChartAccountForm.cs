using ESMART_HMS.Presentation.Forms.Account.BankAccount;
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
        public ChartAccountForm()
        {
            InitializeComponent();
        }



        private void ChartAccountForm_Load(object sender, EventArgs e)
        {
            

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
                
            }
        }
    }
}
