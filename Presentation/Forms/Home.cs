using ESMART_HMS.Presentation.Forms.Customers;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Forms
{
    public partial class Home : Form
    {
        CustomerForm customerForm;
        private readonly CustomerViewModel _customerViewModel;

        public Home(CustomerViewModel customerViewModel)
        {
            InitializeComponent();
            _customerViewModel = customerViewModel;
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            if (customerForm == null)
            {
                customerForm = new CustomerForm(_customerViewModel);
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
                customerForm = new CustomerForm(_customerViewModel);
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
                customerForm = new CustomerForm(_customerViewModel);
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
