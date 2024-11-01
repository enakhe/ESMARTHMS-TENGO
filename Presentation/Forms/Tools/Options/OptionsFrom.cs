using ESMART_HMS.Presentation.Forms.Tools.Option.Financial;
using ESMART_HMS.Presentation.Forms.Tools.Options.Accounts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Tools.Option
{
    public partial class OptionsFrom : Form
    {
        public OptionsFrom()
        {
            InitializeComponent();
        }

        private void OptionsFrom_Load(object sender, EventArgs e)
        {
            treeView.AfterSelect += TreeView1_AfterSelect;
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get the selected node
            TreeNode selectedNode = treeView.SelectedNode;

            // Update the right panel based on the selected node
            UpdateRightPanel(selectedNode.Text);
        }

        private void UpdateRightPanel(string selectedNode)
        {
            // Clear the right panel
            panel1.Controls.Clear();

            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            Form formToLoad = null;

            // Create and load the appropriate form based on the selected item
            switch (selectedNode)
            {
                case "VAT & Discount":
                    formToLoad = serviceProvider.GetRequiredService<FinancialForm>();
                    break;
                case "Users":
                    formToLoad = serviceProvider.GetRequiredService<UserForm>();
                    break;
            }

            if (formToLoad != null)
            {
                formToLoad.TopLevel = false;
                formToLoad.Dock = DockStyle.Fill;
                panel1.Controls.Add(formToLoad);
                formToLoad.Show();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
