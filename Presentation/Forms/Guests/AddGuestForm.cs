using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Guests
{
    public partial class AddGuestForm : Form
    {
        Guest customer = new Guest();
        private readonly GuestController _customerController;
        public AddGuestForm(GuestController customerController)
        {
            InitializeComponent();
            _customerController = customerController;
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

        private void btnGuestImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    customer.GuestImage = File.ReadAllBytes(openFileDialog.FileName);
                    pictureBoxGuest.Image = Image.FromStream(new MemoryStream(customer.GuestImage));
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtTitle.Text, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhoneNumber.Text, txtGender.Text);

                if (isNull == true)
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }

                else
                {
                    Random random = new Random();

                    customer.Id = Guid.NewGuid().ToString();
                    customer.GuestId = "HMS" + random.Next(1000, 5000);
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

                    _customerController.AddGuest(customer);
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
