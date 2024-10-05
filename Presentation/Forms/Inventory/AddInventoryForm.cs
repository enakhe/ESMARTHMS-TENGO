using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Inventory;
using ESMART_HMS.Presentation.Sessions;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Inventory
{
    public partial class AddInventoryForm : Form
    {
        private readonly InventoryController _inventoryController;
        private readonly ApplicationUserController _applicationUserController;
        public AddInventoryForm(InventoryController inventoryController, ApplicationUserController applicationUserController)
        {
            _inventoryController = inventoryController;
            _applicationUserController = applicationUserController;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isNull = FormHelper.AreAnyNullOrEmpty(txtBarcode.Text, txtCategory.Text, txtCostPrice.Text, txtItemType.Text, txtLowStockThreshold.Text, txtMeasurement.Text, txtName.Text, txtQuantity.Text, txtSection.Text, txtSellingPrice.Text);
                if (isNull == false)
                {
                    Random random = new Random();
                    Domain.Entities.MenuItem menuItem = new Domain.Entities.MenuItem()
                    {
                        
                        Id = Guid.NewGuid().ToString(),
                        MenuItemId = "MNU" + random.Next(1000, 5000),
                        Barcode = txtBarcode.Text,
                        ItemName = txtName.Text,
                        Category = txtCategory.Text,
                        CostPrice = decimal.Parse(txtCostPrice.Text),
                        SellingPrice = decimal.Parse(txtSellingPrice.Text),
                        Quantity = int.Parse(txtQuantity.Text),
                        Type = txtItemType.Text,
                        Measurement = txtMeasurement.Text,
                        Section = txtSection.Text,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = AuthSession.CurrentUser.Id,
                        ApplicationUser = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id),
                        IsTrashed = false,
                    };

                    _inventoryController.AddItem(menuItem);

                    Domain.Entities.Inventory inventory = new Domain.Entities.Inventory()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedBy = AuthSession.CurrentUser.Id,
                        ApplicationUser = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id),
                        CurrentStock = menuItem.Quantity,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        InitialStock = menuItem.Quantity,
                        LowStockThreshold = int.Parse(txtLowStockThreshold.Text),
                        MenuItemId = menuItem.Id,
                        MenuItem = menuItem,
                        IsTrashed = false
                    };

                    _inventoryController.AddInventory(inventory);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLowStockThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCostPrice_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtCostPrice.Text);
            if (isNull == false)
            {
                txtCostPrice.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtCostPrice.Text));
            }
        }

        private void txtSellingPrice_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtSellingPrice.Text);
            if (isNull == false)
            {
                txtSellingPrice.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtSellingPrice.Text));
            }
        }
    }
}
