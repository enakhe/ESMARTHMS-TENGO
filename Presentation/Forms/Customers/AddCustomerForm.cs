using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Customers
{
    public partial class AddCustomerForm : Form
    {
        Customer customer = new Customer();
        private readonly CustomerController _customerController;
        public AddCustomerForm(CustomerController customerController)
        {
            InitializeComponent();
            _customerController = customerController;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var closeForm = MessageBox.Show("Are you sure you want to close this form?", "Confirm Closure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (closeForm == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTitle.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "" || txtEmail.Text == "" || txtStreet.Text == "" || txtCity.Text == "" || txtState.Text == "" || txtCountry.Text == "" || txtCompany.Text == "" || txtPhoneNumber.Text == "")
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }

                else
                {
                    customer.Title = txtTitle.Text.Trim().ToUpper();
                    customer.FirstName = txtFirstName.Text.Trim().ToUpper();
                    customer.LastName = txtLastName.Text.Trim().ToUpper();
                    customer.FullName = (txtFirstName.Text + " " + txtLastName.Text).ToUpper();
                    customer.Email = txtEmail.Text.Trim().ToUpper();
                    customer.Street = txtStreet.Text.Trim().ToUpper();
                    customer.City = txtCity.Text.Trim().ToUpper();
                    customer.State = txtState.Text.Trim().ToUpper();
                    customer.Country = txtCountry.Text.Trim().ToUpper();
                    customer.Company = txtCompany.Text.Trim().ToUpper();
                    customer.PhoneNumber = txtPhoneNumber.Text.Trim().ToUpper();
                    customer.DateCreated = DateTime.Now;
                    customer.DateModified = DateTime.Now;

                    _customerController.AddCustomer(customer);
                    this.DialogResult = DialogResult.OK;


                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

        }
    }
}
