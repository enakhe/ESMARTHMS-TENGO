using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Bar;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace ESMART_HMS.Presentation.Forms.Bar
{
    public partial class OrderForm : Form
    {
        private readonly BarItemController _barItemController;
        private readonly GuestController _guestController;
        private readonly ApplicationUserController _applicationUserController;
        private readonly OrderController _orderController;
        private readonly TransactionController _transactionController;
        public OrderForm(BarItemController barItemController, GuestController guestController, ApplicationUserController applicationUserController, OrderController orderController, TransactionController transactionController)
        {
            _barItemController = barItemController;
            _guestController = guestController;
            _orderController = orderController;
            _applicationUserController = applicationUserController;
            InitializeComponent();
            LoadData();
            LoadCustomer();
            _transactionController = transactionController;
        }

        public void LoadData()
        {
            List<BarItemViewModel> barItems = _barItemController.GetAllBarItem();
            if (barItems != null)
            {
                foreach (var item in barItems)
                {
                    CreateItemPanel(item);
                }
            }
            txtGrandTotal.ReadOnly = true;
        }

        public void LoadCustomer()
        {
            List<GuestViewModel> allGuest = _guestController.LoadGuests();
            if (allGuest != null)
            {
                txtCustomer.DataSource = allGuest;
            }
        }

        private void CreateItemPanel(BarItemViewModel item)
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
        }

        private void UpdateTotalPrice(CheckBox checkBox, NumericUpDown quantity, Label totalLabel, BarItemViewModel item)
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

        private void OrderForm_Load(object sender, EventArgs e)
        {

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
                List<BarItemViewModel> filteredItem = _barItemController.FilterBarItem(textBox1.Text);
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

        private void button1_Click(object sender, EventArgs e)
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
                    Domain.Entities.MenuItem barItem = _barItemController.GetBarItemById(itemId.Text);
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
                            var guest = _guestController.GetGuestById(txtCustomer.SelectedValue.ToString());
                            order.CustomerId = txtCustomer.SelectedValue.ToString();
                            order.Guest = guest;
                        }
                        
                    }

                    Domain.Entities.Transaction transaction = new Domain.Entities.Transaction()
                    {
                        Id = Guid.NewGuid().ToString(),
                        TransactionId = "TR" + random.Next(1000, 5000),
                        GuestId = order.CustomerId,
                        Guest = order.Guest,
                        ServiceId = order.OrderId,
                        Date = DateTime.Now,
                        Amount = result,
                        Type = "Bar Service",
                        Description = "Bar",
                        Status = "Paid"
                    };

                    _transactionController.AddTransaction(transaction);

                    _orderController.AddOrder(order);
                    _barItemController.UpdateBarItem(barItem);
                    groupBox1.Controls.Clear();
                    flowLayoutPanelItems.Controls.Clear();
                    LoadData();
                    txtGrandTotal.Text = "";
                }
                else
                {
                    MessageBox.Show("Please provide all fields", "Error", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                }
            }
            MessageBox.Show("Successfully made order", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
        }
    }
}
