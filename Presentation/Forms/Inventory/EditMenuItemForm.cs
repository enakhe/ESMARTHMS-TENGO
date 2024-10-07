using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers.Inventory;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Inventory
{
    public partial class EditMenuItemForm : Form
    {
        private readonly InventoryController _inventoryController;
        private readonly string _id;
        public EditMenuItemForm(InventoryController inventoryController, string id)
        {
            _inventoryController = inventoryController;
            _id = id;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                Domain.Entities.Inventory inventory = _inventoryController.GetInventoryById(_id);
                if (inventory != null)
                {
                    txtSection.Text = inventory.MenuItem.Section;
                    txtBarcode.Text = inventory.MenuItem.Barcode;
                    txtName.Text = inventory.MenuItem.ItemName;
                    txtCategory.Text = inventory.MenuItem.Category;
                    txtQuantity.Text = inventory.MenuItem.Quantity.ToString();
                    txtCostPrice.Text = inventory.MenuItem.CostPrice.ToString();
                    txtSellingPrice.Text = inventory.MenuItem.SellingPrice.ToString();
                    txtItemType.Text = inventory.MenuItem.Type;
                    txtMeasurement.Text = inventory.MenuItem.Measurement.ToString();
                    txtLowStockThreshold.Text = inventory.LowStockThreshold.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Domain.Entities.Inventory inventory = _inventoryController.GetInventoryById(_id);
                if (inventory != null)
                {
                    inventory.MenuItem.Section = txtSection.Text;
                    inventory.MenuItem.Barcode = txtBarcode.Text;
                    inventory.MenuItem.ItemName = txtName.Text;
                    inventory.MenuItem.Category = txtCategory.Text;
                    inventory.MenuItem.Quantity = int.Parse(txtQuantity.Text);
                    inventory.MenuItem.CostPrice = decimal.Parse(txtCostPrice.Text);
                    inventory.MenuItem.SellingPrice = decimal.Parse(txtSellingPrice.Text);
                    inventory.MenuItem.Type = txtItemType.Text;
                    inventory.MenuItem.Measurement = txtMeasurement.Text;
                    inventory.LowStockThreshold = int.Parse(txtLowStockThreshold.Text);

                    inventory.DateModified = DateTime.Now;
                    inventory.MenuItem.DateModified = DateTime.Now;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtStockAdded_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EditMenuItemForm_Load(object sender, EventArgs e)
        {

        }
    }
}
