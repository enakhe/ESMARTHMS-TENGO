using ESMART_HMS.Presentation.Forms.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Forms
{
    public partial class Home : Form
    {
        CustomersForm customerForm;

        public Home()
        {
            InitializeComponent();
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            if (customerForm == null)
            {
                customerForm = new CustomersForm();
                customerForm.FormClosed += Guests_FormClosed;
                customerForm.MdiParent = this;
                customerForm.Dock = DockStyle.Fill;
                customerForm.Show();
                menuTransition.Start();

            }
            else
            {
                customerForm.Activate();
                menuTransition.Start();

            }
        }

        private void Guests_FormClosed(object sender, FormClosedEventArgs e)
        {
            customerForm = null;
        }

        private void btnGuests_Click_1(object sender, EventArgs e)
        {
            if (customerForm == null)
            {
                customerForm = new CustomersForm();
                customerForm.FormClosed += Guest_FormClosed;
                customerForm.MdiParent = this;
                customerForm.Dock = DockStyle.Fill;
                customerForm.Show();
            }
            else
            {
                customerForm.Activate();
            }
        }

        private void Guest_FormClosed(object sender, FormClosedEventArgs e)
        {
            customerForm = null;
        }


        private void addCustonerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (customerForm == null)
            {
                customerForm = new CustomersForm();
                customerForm.FormClosed += Guest_FormClosed;
                customerForm.MdiParent = this;
                customerForm.Dock = DockStyle.Fill;
                customerForm.Show();
            }
            else
            {
                customerForm.Activate();
            }
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
