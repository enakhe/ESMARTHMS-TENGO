using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Forms.FrontDesk.Room;
using ESMART_HMS.Presentation.Forms.Rooms;
using ESMART_HMS.Presentation.Forms.RoomTypes;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Maintenance.SystemSetup
{
    public partial class SystemSetupFrom : Form
    {
        private readonly SystemSetupController _sytemSetupController;
        private readonly RoomController _roomController;
        private readonly RoomTypeController _roomTypeController;
        private readonly BookingController _bookingController;
        byte[] companyLogo;

        public SystemSetupFrom(SystemSetupController sytemSetupController, RoomController roomController, RoomTypeController roomTypeController, BookingController bookingController)
        {
            _sytemSetupController = sytemSetupController;
            _roomController = roomController;
            _roomTypeController = roomTypeController;
            InitializeComponent();
            tabControl1.Appearance = TabAppearance.Normal;
            InitializeCompanyTab(company);
            _bookingController = bookingController;
        }

        private void InitializeCompanyTab(TabPage tabPage)
        {
            if (tabPage != null)
            {
                if (tabPage.Text == "Company")
                {
                    CompanyInformation companyInfo = _sytemSetupController.GetCompanyInfo();
                    if (company != null)
                    {
                        if (companyInfo != null)
                        {
                            txtId.Text = companyInfo.Id;
                            txtName.Text = companyInfo?.Name;
                            txtAddressOne.Text = companyInfo?.AddressLine1;
                            txtAddressTwo.Text = companyInfo?.AddressLine2;
                            txtPhoneNumber.Text = companyInfo?.PhoneNumber;
                            txtEmail.Text = companyInfo?.Email;
                            txtWebsite.Text = companyInfo?.WebsiteURL;
                            txtTaxNumber.Text = companyInfo?.TaxNumber;
                            txtNoOfEmployees.Text = companyInfo?.NoOfEmployees;
                            if (companyInfo != null)
                            {
                                if (companyInfo.Logo != null)
                                {
                                    companyLogoBox.Image = Image.FromStream(new MemoryStream(companyInfo?.Logo));
                                }
                            }
                        }
                    }
                }
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tabPage = tabControl.TabPages[e.Index];

            Rectangle tabRect = tabControl.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);

            Color backColor;

            if (tabPage.Text == "Company")
            {
                backColor = ColorTranslator.FromHtml("#98b4d0");
            }
            else if (tabPage.Text == "General")
            {
                backColor = ColorTranslator.FromHtml("#EF5A6F");
            }
            else if (tabPage.Text == "Bank Account")
            {
                backColor = ColorTranslator.FromHtml("#80AF81");
            }
            else if (tabPage.Text == "Room")
            {
                backColor = ColorTranslator.FromHtml("#98b4d0");
            }
            else
            {
                backColor = e.State == DrawItemState.Selected ? Color.LightBlue : Color.LightGray;
            }

            using (Brush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }

            Font font = new Font("Segoe UI", 13, FontStyle.Bold);

            TextRenderer.DrawText(e.Graphics, tabPage.Text, font, tabRect, tabPage.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    companyLogo = File.ReadAllBytes(openFileDialog.FileName);
                    companyLogoBox.Image = Image.FromStream(new MemoryStream(companyLogo));
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtName.Text);
            bool isIdNull = FormHelper.AreAnyNullOrEmpty(txtId.Text);
            if (isNull)
            {
                MessageBox.Show("Please enter at leaset the company's name", "Invalid Credentials", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            }
            else if (isIdNull == false)
            {
                CompanyInformation foundCompany = _sytemSetupController.GetCompanyInfo();
                if (foundCompany != null)
                {
                    foundCompany.Name = txtName.Text;
                    foundCompany.AddressLine1 = txtAddressOne.Text.Trim().ToUpper();
                    foundCompany.AddressLine2 = txtAddressTwo.Text.Trim().ToUpper();
                    foundCompany.PhoneNumber = txtPhoneNumber.Text;
                    foundCompany.Email = txtEmail.Text;
                    foundCompany.WebsiteURL = txtWebsite.Text;
                    foundCompany.TaxNumber = txtTaxNumber.Text;
                    foundCompany.NoOfEmployees = txtNoOfEmployees.Text;
                    foundCompany.Logo = companyLogo;
                    foundCompany.DateModified = DateTime.Now;

                    _sytemSetupController.SetupCompanyInfo(foundCompany);
                }
            }
            else
            {
                Random random = new Random();
                CompanyInformation companyInformation = new CompanyInformation()
                {
                    Id = "0a06ec2e-7d3e-446e-9b35-9aa2a8898e6b",
                    CompanyId = "COM001",
                    Name = txtName.Text.Trim().ToUpper(),
                    AddressLine1 = txtAddressOne.Text.Trim().ToUpper(),
                    AddressLine2 = txtAddressTwo.Text.Trim().ToUpper(),
                    PhoneNumber = txtPhoneNumber.Text,
                    Email = txtEmail.Text,
                    WebsiteURL = txtWebsite.Text,
                    TaxNumber = txtTaxNumber.Text,
                    NoOfEmployees = txtNoOfEmployees.Text,
                    Logo = companyLogo,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };

                _sytemSetupController.SetupCompanyInfo(companyInformation);
            }
        }

        private void SystemSetupFrom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eSMART_HMSDBDataSet.RoomType' table. You can move, or remove it, as needed.
            this.roomTypeTableAdapter.Fill(this.eSMART_HMSDBDataSet.RoomType);
            // TODO: This line of code loads data into the 'eSMART_HMSDBDataSet.Room' table. You can move, or remove it, as needed.
            this.roomTableAdapter.Fill(this.eSMART_HMSDBDataSet.Room);
        }
    }
}
