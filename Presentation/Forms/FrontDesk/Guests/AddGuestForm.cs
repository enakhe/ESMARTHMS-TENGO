using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Sessions;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Guests
{
    public partial class AddGuestForm : Form
    {
        Guest guest = new Guest();
        private readonly GuestController _guestController;
        private readonly ApplicationUserController _applicationUserController;
        public AddGuestForm(GuestController guestController, ApplicationUserController applicationUserController)
        {
            InitializeComponent();
            _guestController = guestController;
            _applicationUserController = applicationUserController;
        }

        private void btnCaptureFront_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    guest.IdentificationDocumentFront = File.ReadAllBytes(openFileDialog.FileName);
                    pictureBoxFront.Image = Image.FromStream(new MemoryStream(guest.IdentificationDocumentFront));
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
                    guest.IdentificationDocumentBack = File.ReadAllBytes(openFileDialog.FileName);
                    pictureBoxBack.Image = Image.FromStream(new MemoryStream(guest.IdentificationDocumentBack));
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
                    guest.GuestImage = File.ReadAllBytes(openFileDialog.FileName);
                    pictureBoxGuest.Image = Image.FromStream(new MemoryStream(guest.GuestImage));
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

                    guest.Id = Guid.NewGuid().ToString();
                    guest.GuestId = "HMS" + random.Next(1000, 5000);
                    guest.IsTrashed = false;

                    guest.Title = txtTitle.Text.Trim().ToUpper();
                    guest.FirstName = txtFirstName.Text.Trim().ToUpper();
                    guest.LastName = txtLastName.Text.Trim().ToUpper();
                    guest.FullName = (txtFirstName.Text + " " + txtLastName.Text).ToUpper();
                    guest.Email = txtEmail.Text.Trim();
                    guest.Street = txtStreet.Text.Trim().ToUpper();
                    guest.City = txtCity.Text.Trim().ToUpper();
                    guest.State = txtState.Text.Trim().ToUpper();
                    guest.Country = txtCountry.Text.Trim().ToUpper();
                    guest.Company = txtCompany.Text.Trim().ToUpper();
                    guest.PhoneNumber = txtPhoneNumber.Text.Trim().ToUpper();
                    guest.IdType = txtIdType.Text.Trim();
                    guest.IdNumber = txtIdNumber.Text.Trim();
                    guest.Gender = txtGender.Text.Trim();
                    guest.DateCreated = DateTime.Now;
                    guest.DateModified = DateTime.Now;
                    guest.CreatedBy = AuthSession.CurrentUser.Id;
                    guest.ApplicationUser = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);

                    _guestController.AddGuest(guest);
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

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
