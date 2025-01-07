using ESMART_HMS.Presentation.Forms.Inventory;
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

namespace ESMART_HMS.Presentation.Forms.RoleHome
{
    public partial class InventoryHomeForm : Form
    {
        MenuItemForm menuItemForm;
        public InventoryHomeForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            LockApp lockApp = serviceProvider.GetRequiredService<LockApp>();
            lockApp.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to close the application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void inventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (menuItemForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                menuItemForm = serviceProvider.GetRequiredService<MenuItemForm>();
                menuItemForm.FormClosed += MenuItem_FormClosed;
                menuItemForm.MdiParent = this;
                menuItemForm.Dock = DockStyle.Fill;
                menuItemForm.Show();
            }
            else
            {
                menuItemForm.Activate();
            }
        }

        private void MenuItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuItemForm = null;
        }
    }
}
