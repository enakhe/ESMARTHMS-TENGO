using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Bar.BarStore
{
    public partial class EditBarItemForm : Form
    {
        private readonly BarItemController _barItemController;
        private readonly string _id;
        public EditBarItemForm(BarItemController barItemController, string id)
        {
            _id = id;
            _barItemController = barItemController;
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                Domain.Entities.MenuItem barItem = _barItemController.GetBarItemById(_id);
                if (barItem != null)
                {
                    txtBarcode.Text = barItem.Barcode;
                    txtCostPrice.Text = barItem.CostPrice.ToString();
                    txtItemType.Text = barItem.Type;
                    txtMeasurement.Text = barItem.Measurement;
                    txtName.Text = barItem.ItemName;
                    txtQuantity.Text = barItem.Quantity.ToString();
                    txtSellingPrice.Text = barItem.SellingPrice.ToString();
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
            bool isNull = FormHelper.AreAnyNullOrEmpty(txtBarcode.Text, txtName.Text, txtQuantity.Text, txtItemType.Text, txtMeasurement.Text, txtCostPrice.Text);
            if (isNull)
            {
                MessageBox.Show("Add all necessary fields", "Invalid Credentials", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                Domain.Entities.MenuItem barItem = _barItemController.GetBarItemById(_id);
                barItem.Barcode = txtBarcode.Text;
                barItem.CostPrice = decimal.Parse(txtCostPrice.Text);
                barItem.SellingPrice = decimal.Parse(txtSellingPrice.Text);
                barItem.Type = txtItemType.Text;
                barItem.Measurement = txtMeasurement.Text;
                barItem.Quantity = int.Parse(txtQuantity.Text);
                barItem.ItemName = txtName.Text;

                _barItemController.UpdateBarItem(barItem);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void EditBarItemForm_Load(object sender, EventArgs e)
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
