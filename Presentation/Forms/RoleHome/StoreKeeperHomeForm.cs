using ESMART_HMS.Presentation.Forms.Inventory.Store;
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
    public partial class StoreKeeperHomeForm : Form
    {
        StoreForm storeForm;
        public StoreKeeperHomeForm()
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

        private void storeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (storeForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                storeForm = serviceProvider.GetRequiredService<StoreForm>();
                storeForm.FormClosed += Store_FormClosed;
                storeForm.MdiParent = this;
                storeForm.Dock = DockStyle.Fill;
                storeForm.Show();
            }
            else
            {
                storeForm.Activate();
            }
        }

        private void Store_FormClosed(object sender, FormClosedEventArgs e)
        {
            storeForm = null;
        }
    }
}
