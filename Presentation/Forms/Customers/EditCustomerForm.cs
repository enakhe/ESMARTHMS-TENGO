using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Customers
{
    public partial class EditCustomer : Form
    {
        private readonly string _Id;
        private readonly CustomerController _customerController;

        public EditCustomer(string Id, CustomerController customerViewModel)
        {
            InitializeComponent();
            _Id = Id;
            _customerController = customerViewModel;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            try
            {
                Customer customer = _customerController.GetCustomerById(_Id);
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
                Customer customer = _customerController.GetCustomerById(_Id);
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

                        _customerController.UpdateCustomer(customer);
                        this.DialogResult = DialogResult.OK;
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
