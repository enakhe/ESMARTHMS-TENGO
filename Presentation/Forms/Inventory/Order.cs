using DocumentFormat.OpenXml.Spreadsheet;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Bar;
using ESMART_HMS.Presentation.Controllers.Inventory;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Inventory
{
    public partial class Order : Form
    {
        private readonly OrderController _orderController;
        private readonly ApplicationUserController _applicationUserController;
        private readonly SystemSetupController _systemSetupController;
        private readonly TransactionController _transactionController;

        public List<Domain.Entities.Order> orderDetails = new List<Domain.Entities.Order>();

        public Order(OrderController orderController, ApplicationUserController applicationUserController, SystemSetupController systemSetupController, TransactionController transactionController)
        {
            _orderController = orderController;
            _applicationUserController = applicationUserController;
            _systemSetupController = systemSetupController;
            InitializeComponent();
            LoadData();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            _transactionController = transactionController;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            splitContainer19.SplitterWidth = 1;
            splitContainer19.BackColor = splitContainer19.Panel1.BackColor;
            dgvMenu.Font = new System.Drawing.Font("Segoe UI", 10);
            LoadData();
            dgvMenu.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        public void LoadData()
        {
            try
            {
                List<OrderViewModel> allOrders = _orderController.GetAllOrders();
                if (allOrders != null)
                {
                    foreach (var orders in allOrders)
                    {
                        FormHelper.TryConvertStringToDecimal(orders.TotalAmount, out decimal totalPrice);

                        orders.TotalAmount = FormHelper.FormatNumberWithCommas(totalPrice);

                        orders.OrderDate = FormHelper.FormatDateTimeWithSuffix(orders.OrderDate);
                    }
                    dgvMenu.DataSource = allOrders;
                    txtCount.Text = allOrders.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public void PrintReceipt(List<Domain.Entities.Order> orderDetails)
        {
            this.orderDetails = orderDetails;

            PrintDocument printDocument = new PrintDocument();
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrintPage += PrintDocument_PrintPage;
                printDocument.PrinterSettings = printDialog.PrinterSettings;
                printDocument.Print();
            }
        }

        public CompanyInformation GetHotelName()
        {
            CompanyInformation companyInformation = _systemSetupController.GetCompanyInfo();
            if (companyInformation != null)
            {
                return companyInformation;
            }

            return null;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            System.Drawing.Font headerFont = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            System.Drawing.Font subHeaderFont = new System.Drawing.Font("Arial", 9, FontStyle.Bold);
            System.Drawing.Font regularFont = new System.Drawing.Font("Arial", 9);
            System.Drawing.Font smallFont = new System.Drawing.Font("Arial", 7);
            int startX = 5;
            int startY = 5;
            int offsetY = 10;

            string hotelName = "";
            string otherInfo = "";
            CompanyInformation hotelInformation = GetHotelName();


            if (hotelInformation != null)
            {
                hotelName = $"{hotelInformation.Name}";
                otherInfo = $"{hotelInformation.AddressLine1}\n{hotelInformation.PhoneNumber}";
            }

            // Logo
            graphics.DrawString(hotelName, headerFont, Brushes.Blue, startX, startY);
            graphics.DrawString(otherInfo, smallFont, Brushes.Blue, startX, startY + offsetY + 10);
            offsetY += 40;

            string issuedBy = _applicationUserController.GetApplicationUserById(orderDetails[0].IssuedBy).FullName;
            string sellerDetails = $"Issued By\n{issuedBy}";
            graphics.DrawString(sellerDetails, smallFont, Brushes.Black, startX, startY + offsetY + 20);
            offsetY += 50;

            graphics.DrawString("Client's Details", subHeaderFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 20;
            string buyerDetails = orderDetails[0].Guest.FullName;
            graphics.DrawString(buyerDetails, smallFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 30;


            // Receipt and Date Details
            graphics.DrawString($"Receipt No: {orderDetails[0].OrderId}", subHeaderFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 20;
            graphics.DrawString($"Receipt Date: {DateTime.Now.ToString("MMM dd, yyyy")}", subHeaderFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 40;

            // Table Headers
            graphics.DrawString("Item", smallFont, Brushes.Black, startX, startY + offsetY);
            graphics.DrawString("QTY", smallFont, Brushes.Black, startX + 130, startY + offsetY);
            graphics.DrawString("Rate", smallFont, Brushes.Black, startX + 160, startY + offsetY);
            graphics.DrawString("Subtotal", smallFont, Brushes.Black, startX + 220, startY + offsetY);
            offsetY += 20;

            for (int i = 0; i < orderDetails.Count; i++)
            {
                graphics.DrawString(orderDetails[i].MenuItem.ItemName, smallFont, Brushes.Black, startX, startY + offsetY);
                graphics.DrawString(orderDetails[i].Quantity.ToString(), smallFont, Brushes.Black, startX + 130, startY + offsetY);
                graphics.DrawString(orderDetails[i].MenuItem.SellingPrice.ToString(), smallFont, Brushes.Black, startX + 160, startY + offsetY);
                graphics.DrawString((orderDetails[i].TotalAmount).ToString(), smallFont, Brushes.Black, startX + 220, startY + offsetY);
                offsetY += 20;
            }

            offsetY += 20;

            // Invoice Summary
            graphics.DrawString("Invoice Summary", subHeaderFont, Brushes.Black, startX, startY + offsetY);
            offsetY += 20;
            graphics.DrawString("Total:", regularFont, Brushes.Black, startX, startY + offsetY);
            graphics.DrawString($"N{FormHelper.FormatNumberWithCommas((decimal)orderDetails.Sum(o => o.TotalAmount))}", regularFont, Brushes.Black, startX + 100, startY + offsetY);
            offsetY += 50;

            graphics.DrawString($"Thank you and have a great day", regularFont, Brushes.Black, startX + 90, startY + offsetY);

        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMenu.SelectedRows.Count > 0)
                {
                    var row = dgvMenu.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                    var order = _orderController.GetOrderById(id);
                    orderDetails.Add(order);
                    PrintReceipt(orderDetails);
                }
                else
                {
                    MessageBox.Show("Please select an order to print receipt.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMenu.SelectedRows.Count > 0)
                {
                    var row = dgvMenu.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                    var order = _orderController.GetOrderById(id);
                    var transaction = _transactionController.GetByServiceIdAndStatus(order.OrderId, "Un Paid");
                    transaction.Status = "Paid";
                    _transactionController.UpdateTransaction(transaction);
                    MessageBox.Show("Please print new receipt", "Successfully Changed to Paid", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("Please select an order to change state.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
