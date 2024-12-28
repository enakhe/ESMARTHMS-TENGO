using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Inventory;
using ESMART_HMS.Presentation.Controllers.Restaurant;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Inventory.Store
{
    public partial class StoreForm : Form
    {
        private readonly InventoryController _inventoryController;
        private readonly ApplicationUserController _applicationUserController;
        public StoreForm(InventoryController inventoryController, ApplicationUserController applicationUserController)
        {
            _inventoryController = inventoryController;
            _applicationUserController = applicationUserController;
            InitializeComponent();
            LoadData();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Activated += StoreForm_Activated;
        }

        public void LoadData()
        {
            try
            {
                List<MenuItemViewModel> allMenuItems = _inventoryController.GetStoreItems();
                if (allMenuItems != null)
                {
                    foreach (var items in allMenuItems)
                    {
                        FormHelper.TryConvertStringToDecimal(items.CostPrice, out decimal costPrice);
                        FormHelper.TryConvertStringToDecimal(items.SellingPrice, out decimal sellingPrice);

                        items.CostPrice = FormHelper.FormatNumberWithCommas(costPrice);
                        items.SellingPrice = FormHelper.FormatNumberWithCommas(sellingPrice);

                        items.DateCreated = FormHelper.FormatDateTimeWithSuffix(items.DateCreated);
                        items.DateModified = FormHelper.FormatDateTimeWithSuffix(items.DateModified);
                    }
                    dgvMenu.DataSource = allMenuItems;
                    txtCount.Text = allMenuItems.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {
            LoadData();
            splitContainer19.SplitterWidth = 1;
            splitContainer19.BackColor = splitContainer19.Panel1.BackColor;
            dgvMenu.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvMenu.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10); 
        }

        private void StoreForm_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
