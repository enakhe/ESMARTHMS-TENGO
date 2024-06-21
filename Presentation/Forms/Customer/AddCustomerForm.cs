using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var closeForm = MessageBox.Show("Are you sure you want to close this form?", "Confirm Closure", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (closeForm == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btnCaptureFront_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    customer.IdentificationDocumentFront = File.ReadAllBytes(openFileDialog.FileName);
                    pictureBoxFront.Image = Image.FromStream(new MemoryStream(customer.IdentificationDocumentFront));
                }
            }
        }


        private void btnCaptureBack_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    customer.IdentificationDocumentBack = File.ReadAllBytes(openFileDialog.FileName);
                    pictureBoxBack.Image = Image.FromStream(new MemoryStream(customer.IdentificationDocumentFront));
                }
            }
        }

        private void btnCustomerImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    customer.CustomerImage = File.ReadAllBytes(openFileDialog.FileName);
                    pictureBoxCustomer.Image = Image.FromStream(new MemoryStream(customer.CustomerImage));
                }
            }
        }

        private void AddCustomerForm_FormClosed(object sender, FormClosedEventArgs e)
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
                if (txtTitle.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "" || txtEmail.Text == "" || txtStreet.Text == "" || txtCity.Text == "" || txtCountry.Text == "" || txtState.Text == "" || txtCompany.Text == "" || txtPhoneNumber.Text == "")
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }

                else
                {
                    Random random = new Random();

                    customer.Id = Guid.NewGuid().ToString();
                    customer.CustomerId = "HMS" + random.Next(1000, 5000);
                    customer.IsTrashed = false;

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
                    customer.IdType = txtIdType.Text.Trim();
                    customer.IdNumber = txtIdNumber.Text.Trim();
                    customer.Gender = txtGender.Text.Trim();
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
