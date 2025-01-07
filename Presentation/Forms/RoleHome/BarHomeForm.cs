using ESMART_HMS.Presentation.Forms.Store.BarStore;
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
    public partial class BarHomeForm : Form
    {
        Presentation.Forms.Inventory.Order orderForm;
        BarStoreForm barStoreForm;
        public BarHomeForm()
        {
            InitializeComponent();
        }

        private void ordersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (orderForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                orderForm = serviceProvider.GetRequiredService<Presentation.Forms.Inventory.Order>();
                orderForm.FormClosed += Order_FormClosed;
                orderForm.MdiParent = this;
                orderForm.Dock = DockStyle.Fill;
                orderForm.Show();
            }
            else
            {
                orderForm.Activate();
            }
        }

        private void Order_FormClosed(object sender, FormClosedEventArgs e)
        {
            orderForm = null;
        }

        private void barToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (barStoreForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                barStoreForm = serviceProvider.GetRequiredService<BarStoreForm>();
                barStoreForm.FormClosed += BarStore_FormClosed;
                barStoreForm.MdiParent = this;
                barStoreForm.Dock = DockStyle.Fill;
                barStoreForm.Show();
            }
            else
            {
                barStoreForm.Activate();
            }
        }

        private void BarStore_FormClosed(object sender, FormClosedEventArgs e)
        {
            barStoreForm = null;
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
    }
}
