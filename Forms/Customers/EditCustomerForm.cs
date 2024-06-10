using ESMART_HMS.Forms.Guests;
using ESMART_HMS.Models;
using ESMART_HMS.Repositories;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Forms.Customers
{
    public partial class EditCustomer : Form
    {
        CustomersForm customersForm = new CustomersForm();
        private readonly string _Id;

        public EditCustomer(string Id)
        {
            InitializeComponent();
            _Id = Id;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            try
            {
                ESMART_HMSDBEntities _db = new ESMART_HMSDBEntities();
                CustomerRepository customerRepository = new CustomerRepository(_db);

                var customer = customerRepository.GetCustomer(_Id);
                if (customer == null)
                {
                    MessageBox.Show("Customer not found", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    txtId.Text = customer.Id;
                    txtTitle.Text = customer.Title;
                    txtFirstName.Text = customer.FirstName;
                    txtLastName.Text = customer.LastName;
                    txtEmail.Text = customer.Email;
                    txtStreet.Text = customer.Street;
                    txtCity.Text = customer.City;
                    txtState.Text = customer.State;
                    txtCountry.Text = customer.Country;
                    txtCompany.Text = customer.Company;
                    txtPhoneNumber.Text = customer.PhoneNumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
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
                ESMART_HMSDBEntities _db = new ESMART_HMSDBEntities();
                CustomerRepository customerRepository = new CustomerRepository(_db);

                var customer = customerRepository.GetCustomer(_Id);
                if (customer == null)
                {
                    MessageBox.Show("Customer not found", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
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
                        customer.DateModified = DateTime.Now;

                        customerRepository.EditCustomer(customer);
                        this.DialogResult = DialogResult.OK;

                        customersForm.LoadData();
                        this.Close();
                    }
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
