using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Guests
{
    public partial class ViewGuestForm : Form
    {
        private readonly GuestController _customerController;
        private readonly string _Id;
        public ViewGuestForm(string Id, GuestController customerViewModel)
        {
            InitializeComponent();
            _customerController = customerViewModel;
            _Id = Id;
            LoadGuestData();
            CenterLabel();
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
                    txtGuestId.Text = customer.GuestId;
                    //txtFullName.Text = customer.FullName;
                    txtFullName.Text = $"{customer.Title} {customer.FullName}";
                    txtEmail.Text = customer.Email;
                    txtAddress.Text = $"{customer.Street}, {customer.City}, {customer.State}, {customer.Country}";
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = txtGuestId.Text;
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
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
                    string customerId = customer.GuestId;
                    string firstName = customer.FullName;
                    string lastName = customer.LastName;
                    string email = customer.Email;
                    string street = customer.Street;
                    string city = customer.City;
                    string state = customer.State;
                    string country = customer.Country;
                    string phoneNumber = customer.PhoneNumber;

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Guest Details");
                    sb.AppendLine($"Guest ID: {customerId}");
                    sb.AppendLine($"First Name: {firstName}");
                    sb.AppendLine($"Last Name: {lastName}");
                    sb.AppendLine($"Email: {email}");
                    sb.AppendLine($"Address: {street}, {city}, {state}, {country}");
                    sb.AppendLine($"Phone Number: {phoneNumber}");

                    e.Graphics.DrawString(sb.ToString(), new Font("Segeo UI", 12), Brushes.Black, new PointF(100, 100));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void ViewGuestForm_Load(object sender, EventArgs e)
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

        private void CenterLabel()
        {
            txtGuestId.AutoSize = true;
            txtGuestId.TextAlign = ContentAlignment.MiddleCenter;

            int x = (namePanel.Width - label1.Width) / 2;
            int y = (namePanel.Height - label1.Height) / 2;

            txtGuestId.Location = new Point(x, y);

            namePanel.Resize += (s, e) =>
            {
                x = (namePanel.Width - txtGuestId.Width) / 2;
                y = (namePanel.Height - txtGuestId.Height) / 2;
                txtGuestId.Location = new Point(x, y);
            };
        }
    }
}
