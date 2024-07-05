using ESMART_HMS.Presentation.Forms.Tools.Option.Financial;
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

            FinancialForm financialForm = new FinancialForm();

            // Update the right panel based on the selected node
            UpdateRightPanel(selectedNode.Text);
        }

        private void UpdateRightPanel(string selectedNode)
        {
            // Clear the right panel
            panel1.Controls.Clear();

            Form formToLoad = null;

            // Create and load the appropriate form based on the selected item
            switch (selectedNode)
            {
                case "General":
                    formToLoad = new FinancialForm();
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
    }
}
