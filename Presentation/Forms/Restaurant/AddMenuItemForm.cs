using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Restaurant;
using ESMART_HMS.Presentation.Sessions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Restaurant
{
    public partial class AddMenuItemForm : Form
    {
        private readonly RestaurantContoller _restaurantContoller;
        private readonly ApplicationUserController _applicationUserController;

        public AddMenuItemForm(RestaurantContoller restaurantContoller, ApplicationUserController applicationUserController)
        {
            _restaurantContoller = restaurantContoller;
            _applicationUserController = applicationUserController;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtBarcode.Text, txtCategory.Text, txtName.Text, txtQuantity.Text, txtItemType.Text, txtMeasurement.Text, txtCostPrice.Text);
            if (isNull)
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                Random random = new Random();
                Domain.Entities.MenuItem menuItem = new Domain.Entities.MenuItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    MenuItemId = "MEIT" + random.Next(1000, 4000),
                    Barcode = txtBarcode.Text,
                    ItemName = txtName.Text.ToUpper(),
                    CostPrice = decimal.Parse(txtCostPrice.Text),
                    SellingPrice = decimal.Parse(txtSellingPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Type = txtItemType.Text,
                    Category = txtCategory.Text,
                    Measurement = txtMeasurement.Text,

                    ApplicationUser = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id),
                    CreatedBy = AuthSession.CurrentUser.Id,

                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };
                _restaurantContoller.AddItem(menuItem);
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void txtSellingPrice_TextChanged(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtSellingPrice.Text);
            if (!isNull)
            {
                txtSellingPrice.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtSellingPrice.Text));
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
    }
}
