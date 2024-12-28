//using ESMART_HMS.Presentation.Controllers.Bar;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Bar;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Controllers.Restaurant;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESMART_HMS.Presentation.Forms.Restaurant
{
    public partial class OrderForm : Form
    {
        private readonly RestaurantContoller _restaurantContoller;
        private readonly GuestController _guestController;
        private readonly ApplicationUserController _applicationUserController;
        private readonly RoomController _roomController;
        private readonly OrderController _orderController;
        private readonly TransactionController _transactionController;
        private readonly SystemSetupController _systemSetupController;
        private readonly bookingController _bookingController;
        private readonly ESMART_HMSDBEntities _db;

        public List<Order> orderDetails = new List<Order>();
        string status;

        public OrderForm(RestaurantContoller restaurantContoller, GuestController guestController, ApplicationUserController applicationUserController, TransactionController transactionController, OrderController orderController, SystemSetupController systemSetupController, RoomController roomController, bookingController bookingController, ESMART_HMSDBEntities db)
        {
            _restaurantContoller = restaurantContoller;
            _guestController = guestController;
            _applicationUserController = applicationUserController;
            _transactionController = transactionController;
            _systemSetupController = systemSetupController;
            _roomController = roomController;
            _transactionController = transactionController;
            _orderController = orderController;
            _bookingController = bookingController;
            _db = db;

            InitializeComponent();
            LoadData();
            LoadCustomer();
        }

        public void LoadData()
        {
            List<MenuItemViewModel> menuItem = _restaurantContoller.GetMenuItems();
            if (menuItem != null)
            {
                foreach (var item in menuItem.OrderBy(i => i.ItemName).ToList())
                {
                    CreateItemPanel(item);
                }
            }
            txtGrandTotal.ReadOnly = true;
        }

        public void LoadCustomer()
        {
            List<RoomViewModel> rooms = _roomController.GetAllRooms();
            var bookings = _bookingController.GetAllbookings();
            if (bookings != null)
            {
                txtCustomer.DataSource = bookings.Select(b => b.Room).ToList();
            }
        }

        private void CreateItemPanel(MenuItemViewModel item)
        {
            Font defaultFont = new Font("Segoe UI", 12);

            Panel itemPanel = new Panel();
            itemPanel.Width = 300;
            itemPanel.Height = 150;
            itemPanel.BackColor = Color.DarkBlue;
            itemPanel.ForeColor = Color.White;
            itemPanel.Padding = new Padding(20);
            itemPanel.Left = 30;
            itemPanel.BorderStyle = BorderStyle.FixedSingle;

            CheckBox chkItemSelected = new CheckBox();
            chkItemSelected.Text = "";
            chkItemSelected.Width = 20;
            chkItemSelected.Top = 5;
            chkItemSelected.Left = 5;

            Label itemId = new Label();
            itemId.Text = item.Id;
            itemId.Visible = false;
            itemId.Top = 6;

            Label lblItemName = new Label();
            lblItemName.Text = item.ItemName;
            lblItemName.Width = 290;
            lblItemName.Top = 5;
            lblItemName.Left = 30;
            lblItemName.Font = new Font("Segoe UI", 15);

            Label lblItemsLeft = new Label();
            lblItemsLeft.Text = "Items Left: " + item.Quantity;
            lblItemsLeft.Width = 180;
            lblItemsLeft.Top = 40;
            lblItemsLeft.Left = 30;
            lblItemsLeft.Font = defaultFont;

            NumericUpDown txtQuantity = new NumericUpDown();
            txtQuantity.Value = 0;
            txtQuantity.Minimum = 0;
            txtQuantity.Maximum = decimal.Parse(item.Quantity);
            txtQuantity.Width = 50;
            txtQuantity.Top = 70;
            txtQuantity.Left = 30;
            txtQuantity.Font = defaultFont;
            txtQuantity.Enabled = false;
            txtQuantity.Font = defaultFont;


            Label lblUnitPrice = new Label();
            lblUnitPrice.Text = "Unit Price: " + FormHelper.FormatNumberWithCommas(decimal.Parse(item.SellingPrice));
            lblUnitPrice.Width = 180;
            lblUnitPrice.Top = 70;
            lblUnitPrice.Left = 100;
            lblUnitPrice.Font = defaultFont;

            Label lblTotalPrice = new Label();
            lblTotalPrice.Text = "Total: 0";
            lblTotalPrice.Width = 180;
            lblTotalPrice.Top = 120;
            lblTotalPrice.Left = 30;
            lblUnitPrice.Font = defaultFont;


            chkItemSelected.CheckedChanged += (sender, e) =>
            {
                txtQuantity.Enabled = chkItemSelected.Checked;
                UpdateTotalPrice(chkItemSelected, txtQuantity, lblTotalPrice, item);
                UpdateGrandTotal();
                UpdateSelectedItemsList();
            };

            txtQuantity.ValueChanged += (sender, e) =>
            {
                UpdateTotalPrice(chkItemSelected, txtQuantity, lblTotalPrice, item);
                UpdateGrandTotal();
                UpdateSelectedItemsList();
            };

            if (int.Parse(item.Quantity) == 0)
            {
                itemPanel.Enabled = false;
            }

            itemPanel.Controls.Add(itemId);
            itemPanel.Controls.Add(chkItemSelected);
            itemPanel.Controls.Add(lblItemName);
            itemPanel.Controls.Add(lblItemsLeft);
            itemPanel.Controls.Add(txtQuantity);
            itemPanel.Controls.Add(lblUnitPrice);
            itemPanel.Controls.Add(lblTotalPrice);

            flowLayoutPanelItems.Controls.Add(itemPanel);
            flowLayoutPanelItems.AutoScroll = true;
        }

        private void UpdateTotalPrice(CheckBox checkBox, NumericUpDown quantity, Label totalLabel, MenuItemViewModel item)
        {
            if (checkBox.Checked && decimal.TryParse(item.SellingPrice, out decimal price))
            {
                decimal total = quantity.Value * price;
                totalLabel.Text = "Total: " + FormHelper.FormatNumberWithCommas(total);
                totalLabel.Font = new Font("Segoe UI", 12);
            }
            else
            {
                totalLabel.Font = new Font("Segoe UI", 12);
                totalLabel.Text = "Total: 0";
            }
        }

        private void UpdateGrandTotal()
        {
            decimal grandTotal = 0;
            foreach (Panel panel in flowLayoutPanelItems.Controls)
            {
                CheckBox checkBox = panel.Controls.OfType<CheckBox>().FirstOrDefault();
                Label totalLabel = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text.StartsWith("Total:"));
                if (checkBox != null && checkBox.Checked)
                {
                    string totalText = totalLabel.Text.Split(':')[1].Trim();
                    if (decimal.TryParse(totalText, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal total))
                    {
                        grandTotal += total;
                    }
                }
            }
            txtGrandTotal.Text = FormHelper.FormatNumberWithCommas(grandTotal);
        }

        private void UpdateSelectedItemsList()
        {
            groupBox1.Controls.Clear();

            int yOffset = 20;
            foreach (Panel panel in flowLayoutPanelItems.Controls)
            {
                CheckBox checkBox = panel.Controls.OfType<CheckBox>().FirstOrDefault();
                NumericUpDown numQuantity = panel.Controls.OfType<NumericUpDown>().FirstOrDefault();
                Label itemNameLabel = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text != null && lbl.Top == 5);
                Label totalLabel = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text.StartsWith("Total:"));

                if (checkBox != null && checkBox.Checked && numQuantity != null && itemNameLabel != null && totalLabel != null)
                {
                    Label selectedItemLabel = new Label();
                    selectedItemLabel.Text = $"- {itemNameLabel.Text}: {numQuantity.Value} ({FormHelper.FormatNumberWithCommas(decimal.Parse(totalLabel.Text.Split(':')[1].Trim()))})";
                    selectedItemLabel.AutoSize = true;
                    selectedItemLabel.Top = yOffset;
                    selectedItemLabel.Left = 10;
                    selectedItemLabel.Font = new Font("Segoe UI", 12);

                    groupBox1.Controls.Add(selectedItemLabel);
                    yOffset += 30;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtCustomer.Enabled = false;
            }
            else
            {
                txtCustomer.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanelItems.Controls.Clear();
            bool isNull = FormHelper.AreAnyNullOrEmpty(textBox1.Text);
            if (isNull == false)
            {
                List<MenuItemViewModel> filteredItem = _restaurantContoller.FilterItem(textBox1.Text);
                if (filteredItem != null)
                {
                    foreach (var item in filteredItem)
                    {
                        CreateItemPanel(item);
                    }
                }
            }
            else
            {
                LoadData();
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

        public void PrintReceipt(List<Order> orderDetails, string status)
        {
            this.orderDetails = orderDetails;
            this.status = status;

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

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font subHeaderFont = new Font("Arial", 9, FontStyle.Bold);
            Font regularFont = new Font("Arial", 9);
            Font smallFont = new Font("Arial", 7);
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

        private async void button1_Click(object sender, EventArgs e)
        {
            foreach (Panel panel in flowLayoutPanelItems.Controls)
            {
                CheckBox checkBox = panel.Controls.OfType<CheckBox>().FirstOrDefault();
                NumericUpDown numQuantity = panel.Controls.OfType<NumericUpDown>().FirstOrDefault();
                Label itemNameLabel = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text != null && lbl.Top == 5);
                Label totalLabel = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text.StartsWith("Total:"));
                Label itemId = panel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text != null && lbl.Top == 6);

                bool isNull = checkBox != null && checkBox.Checked && numQuantity != null && itemNameLabel != null && totalLabel != null && itemId != null && txtCustomer != null;
                if (isNull == true)
                {
                    Domain.Entities.MenuItem barItem = _restaurantContoller.GetMenuItemById(itemId.Text);
                    barItem.Quantity = barItem.Quantity - int.Parse(numQuantity.Text);
                    Order order = new Order();
                    Random random = new Random();

                    decimal result = decimal.Parse(totalLabel.Text.Split(':')[1].Trim(), NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);

                    order.Id = Guid.NewGuid().ToString();
                    order.OrderId = "ORD" + random.Next(1000, 5000);
                    order.ItemId = barItem.Id;
                    order.Quantity = int.Parse(numQuantity.Value.ToString());
                    order.TotalAmount = result;
                    order.ApplicationUser = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
                    order.IssuedBy = AuthSession.CurrentUser.Id;
                    order.OrderDate = DateTime.Now;
                    order.IsTrashed = false;
                    order.MenuItem = barItem;


                    if (checkBox1.Checked)
                    {
                        List<GuestViewModel> guests = _guestController.SearchGuest("Anonymous Guest");
                        if (guests.Count > 0)
                        {
                            var guest = _guestController.GetGuestById(guests[0].Id);
                            order.CustomerId = guest.Id;
                            order.Guest = guest;
                        }
                    }
                    else
                    {
                        if (txtCustomer.SelectedValue.ToString() != null)
                        {
                            var booking = _db.Bookings.FirstOrDefault(b => b.Room.RoomNo == txtCustomer.SelectedValue.ToString());
                            if (booking != null)
                            {
                                order.CustomerId = booking.Guest.Id;
                                order.Guest = booking.Guest;
                            }
                        }

                    }

                    if (txtUnpaid.Checked)
                    {
                        Domain.Entities.Transaction transaction = new Domain.Entities.Transaction()
                        {
                            Id = Guid.NewGuid().ToString(),
                            TransactionId = "TR" + random.Next(1000, 5000),
                            GuestId = order.CustomerId,
                            Guest = order.Guest,
                            ServiceId = order.OrderId,
                            Date = DateTime.Now,
                            Amount = result,
                            Type = "Restaurant Service",
                            Description = "Restaurant",
                            Status = "Un Paid"
                        };
                        _transactionController.AddTransaction(transaction);

                    }
                    else
                    {
                        Domain.Entities.Transaction transaction = new Domain.Entities.Transaction()
                        {
                            Id = Guid.NewGuid().ToString(),
                            TransactionId = "TR" + random.Next(1000, 5000),
                            GuestId = order.CustomerId,
                            Guest = order.Guest,
                            ServiceId = order.OrderId,
                            Date = DateTime.Now,
                            Amount = result,
                            Type = "Restaurant Service",
                            Description = "Restaurant",
                            Status = "Paid"
                        };
                        _transactionController.AddTransaction(transaction);
                    }

                    CompanyInformation foundCompany = _systemSetupController.GetCompanyInfo();

                    string guestCardString = $"Id = {order.Id}\n" +
                         $"Item = {order.MenuItem.ItemName}\n" +
                         $"Guest = {order.Guest.FullName}\n" +
                         $"Amount = {order.TotalAmount}\n" +
                         $"Quantity = {order.Quantity}\n" +
                         $"Issued Time = {order.ApplicationUser.FullName}\n" +
                         $"Order Date = {order.OrderDate}\n";

                    if (foundCompany != null)
                    {
                        if (foundCompany.Email != null)
                        {
                            await EmailHelper.SendEmail(foundCompany.Email, "Order Placed", guestCardString);
                        }
                    }


                    _orderController.AddOrder(order);
                    orderDetails.Add(order);
                    _restaurantContoller.UpdateItem(barItem);
                }
            }
            MessageBox.Show("Successfully made order", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            if (txtUnpaid.Checked)
            {
                status = "Un Paid";
                PrintReceipt(orderDetails, status);
            }
            else
            {
                status = "Paid";
                PrintReceipt(orderDetails, status);
            }
            groupBox1.Controls.Clear();
            flowLayoutPanelItems.Controls.Clear();
            LoadData();
            txtGrandTotal.Text = "";
        }

        private void OrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eSMART_HMSDBDataSet.Room' table. You can move, or remove it, as needed.
            this.roomTableAdapter.Fill(this.eSMART_HMSDBDataSet.Room);

        }
    }
}
