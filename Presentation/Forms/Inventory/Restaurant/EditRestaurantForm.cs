using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers.Restaurant;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Restaurant
{
    public partial class EditRestaurantForm : Form
    {
        private readonly RestaurantContoller _restaurantContoller;
        private readonly string _id;
        public EditRestaurantForm(RestaurantContoller restaurantContoller, string id)
        {
            _restaurantContoller = restaurantContoller;
            _id = id;
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                Domain.Entities.MenuItem menuItem = _restaurantContoller.GetMenuItemById(_id);
                if (menuItem != null)
                {
                    txtBarcode.Text = menuItem.Barcode;
                    txtCostPrice.Text = menuItem.CostPrice.ToString();
                    txtItemType.Text = menuItem.Type;
                    txtCategory.Text = menuItem.Category;
                    txtMeasurement.Text = menuItem.Measurement;
                    txtName.Text = menuItem.ItemName;
                    txtQuantity.Text = menuItem.Quantity.ToString();
                    txtSellingPrice.Text = menuItem.SellingPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtBarcode.Text, txtCategory.Text, txtName.Text, txtQuantity.Text, txtItemType.Text, txtMeasurement.Text, txtCostPrice.Text);
            if (isNull)
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                Domain.Entities.MenuItem menuItem = _restaurantContoller.GetMenuItemById(_id);
                menuItem.Barcode = txtBarcode.Text;
                menuItem.CostPrice = decimal.Parse(txtCostPrice.Text);
                menuItem.SellingPrice = decimal.Parse(txtSellingPrice.Text);
                menuItem.Type = txtItemType.Text;
                menuItem.Category = txtCategory.Text;
                menuItem.Measurement = txtMeasurement.Text;
                menuItem.Quantity = int.Parse(txtQuantity.Text);
                menuItem.ItemName = txtName.Text;

                _restaurantContoller.UpdateItem(menuItem);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void EditRestaurantForm_Load(object sender, EventArgs e)
        {
            LoadData();
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

        private void txtCostPrice_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtCostPrice.Text);
            if (!isNull)
            {
                txtCostPrice.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtCostPrice.Text));
            }
        }

        private void txtSellingPrice_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtCostPrice.Text);
            if (!isNull)
            {
                txtSellingPrice.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtSellingPrice.Text));
            }
        }
    }
}
