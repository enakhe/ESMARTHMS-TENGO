using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
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

namespace ESMART_HMS.Presentation.Forms.Store.BarStore
{
    public partial class AddBarItemForm : Form
    {
        private readonly BarItemController _barItemController;
        private readonly ApplicationUserController _applicationUserController;
        public AddBarItemForm(BarItemController barItemController, ApplicationUserController applicationUserController)
        {
            _barItemController = barItemController;
            _applicationUserController = applicationUserController;
            InitializeComponent();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtBarcode.Text, txtName.Text, txtQuantity.Text, txtItemType.Text, txtMeasurement.Text, txtCostPrice.Text);
            if (isNull)
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                Random random = new Random();
                Domain.Entities.BarItem barItem = new Domain.Entities.BarItem() 
                {
                    Id = Guid.NewGuid().ToString(),
                    BarItemId = "BITM" + random.Next(1000, 4000),
                    Barcode = txtBarcode.Text,
                    ItemName = txtName.Text.ToUpper(),
                    CostPrice = decimal.Parse(txtCostPrice.Text),
                    SellingPrice = decimal.Parse(txtSellingPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Type = txtItemType.Text,
                    Measurement = txtMeasurement.Text,

                    ApplicationUser = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id),
                    CreatedBy = AuthSession.CurrentUser.Id,

                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                };
                _barItemController.AddItem(barItem);
                this.DialogResult = DialogResult.OK;
                this.Close();
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
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtSellingPrice.Text);
            if (!isNull)
            {
                txtSellingPrice.Text = FormHelper.FormatNumberWithCommas(decimal.Parse(txtSellingPrice.Text));
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
    }
}
