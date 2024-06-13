using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Infrastructure.Data;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Customers
{
    public partial class ViewCustomerForm : Form
    {
        private readonly CustomerViewModel _customerViewModel;
        private readonly string _Id;
        public ViewCustomerForm(string Id, CustomerViewModel customerViewModel)
        {
            InitializeComponent();
            _customerViewModel = customerViewModel;
            _Id = Id;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            try
            {
                ESMART_HMSDBEntities _db = new ESMART_HMSDBEntities();
                CustomerRepository customerRepository = new CustomerRepository(_db);

                var customer = customerRepository.GetCustomerById(_Id);
                if (customer == null)
                {
                    MessageBox.Show("Customer not found", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    txtCustomerId.Text = customer.CustomerId;
                    txtFullName.Text = customer.FullName;
                    txtRealFullName.Text = $"{customer.Title} {customer.FullName}";
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
            printDocument.DocumentName = txtRealFullName.Text;
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
                ESMART_HMSDBEntities _db = new ESMART_HMSDBEntities();
                CustomerRepository customerRepository = new CustomerRepository(_db);

                var customer = customerRepository.GetCustomerById(_Id);
                if (customer == null)
                {
                    MessageBox.Show("Customer not found", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    string customerId = customer.CustomerId;
                    string firstName = customer.FullName;
                    string lastName = customer.LastName;
                    string email = customer.Email;
                    string street = customer.Street;
                    string city = customer.City;
                    string state = customer.State;
                    string country = customer.Country;
                    string phoneNumber = customer.PhoneNumber;

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Customer Details");
                    sb.AppendLine($"Customer ID: {customerId}");
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

        private void ViewCustomerForm_Load(object sender, EventArgs e)
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
    }
}
