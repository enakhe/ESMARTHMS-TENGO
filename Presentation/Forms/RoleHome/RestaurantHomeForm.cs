using ESMART_HMS.Presentation.Forms.Maintenance;
using ESMART_HMS.Presentation.Forms.Restaurant;
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
    public partial class RestaurantHomeForm : Form
    {
        Presentation.Forms.Inventory.Order orderForm;
        RestaurantForm restaurantForm;

        public RestaurantHomeForm()
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

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (restaurantForm == null)
            {
                var services = new ServiceCollection();
                DependencyInjection.ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                restaurantForm = serviceProvider.GetRequiredService<RestaurantForm>();
                restaurantForm.FormClosed += Restaurant_FormClosed;
                restaurantForm.MdiParent = this;
                restaurantForm.Dock = DockStyle.Fill;
                restaurantForm.Show();
            }
            else
            {
                restaurantForm.Activate();
            }
        }

        private void Restaurant_FormClosed(object sender, FormClosedEventArgs e)
        {
            restaurantForm = null;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to close the application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            LockApp lockApp = serviceProvider.GetRequiredService<LockApp>();
            lockApp.ShowDialog();
        }
    }
}
