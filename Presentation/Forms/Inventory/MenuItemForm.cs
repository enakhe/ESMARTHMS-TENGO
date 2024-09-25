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

namespace ESMART_HMS.Presentation.Forms.Inventory
{
    public partial class MenuItemForm : Form
    {
        public MenuItemForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void MenuItemForm_Load(object sender, EventArgs e)
        {
            this.inventoryTableAdapter.Fill(this.eSMART_HMSDBDataSet.Inventory);
            splitContainer19.SplitterWidth = 1;
            splitContainer19.BackColor = splitContainer19.Panel1.BackColor;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddInventoryForm addInventoryForm = serviceProvider.GetRequiredService<AddInventoryForm>();
            if (addInventoryForm.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }
}
