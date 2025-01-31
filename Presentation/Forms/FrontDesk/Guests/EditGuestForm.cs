﻿using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace ESMART_HMS.Presentation.Forms.Guests
{
    public partial class EditGuest : Form
    {
        Guest guest = new Guest();
        private readonly string _Id;
        private readonly GuestController _customerController;

        public EditGuest(string Id, GuestController customerViewModel)
        {
            InitializeComponent();
            _Id = Id;
            _customerController = customerViewModel;
            LoadGuestData();
        }

        private void LoadGuestData()
        {
            try
            {
                Guest customer = _customerController.GetGuestById(_Id);
                if (customer == null)
                {
                    MessageBox.Show("Guest not found", "", MessageBoxButtons.OK,
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
                    txtIdType.Text = customer.IdType;
                    txtId.Text = customer.Id;

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
                Guest customer = _customerController.GetGuestById(_Id);
                if (customer == null)
                {
                    MessageBox.Show("Guest not found", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    if (txtTitle.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "" || txtEmail.Text == "" || txtPhoneNumber.Text == "")
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
                        customer.Email = txtEmail.Text.Trim();
                        customer.Street = txtStreet.Text.Trim().ToUpper();
                        customer.City = txtCity.Text.Trim().ToUpper();
                        customer.State = txtState.Text.Trim().ToUpper();
                        customer.Country = txtCountry.Text.Trim().ToUpper();
                        customer.Company = txtCompany.Text.Trim().ToUpper();
                        customer.PhoneNumber = txtPhoneNumber.Text.Trim().ToUpper();
                        customer.DateModified = DateTime.Now;

                        _customerController.UpdateGuest(customer);
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
    }
}
