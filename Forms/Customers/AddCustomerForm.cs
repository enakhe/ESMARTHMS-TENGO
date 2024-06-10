using ESMART_HMS.Forms.Guests;
using ESMART_HMS.Models;
using ESMART_HMS.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace ESMART_HMS.Forms.Customers
{
    public partial class AddCustomerForm : Form
    {
        CustomersForm customersForm = new CustomersForm();
        Customer customer = new Customer();

        public AddCustomerForm()
        {
            InitializeComponent();
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

                    ESMART_HMSDBEntities _db = new ESMART_HMSDBEntities();
                    CustomerRepository customerRepository = new CustomerRepository(_db);

                    customerRepository.AddCustomer(customer);
                    this.DialogResult = DialogResult.OK;

                    customersForm.LoadData();
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
