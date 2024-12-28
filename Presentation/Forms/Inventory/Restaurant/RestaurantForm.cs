using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Restaurant;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Restaurant
{
    public partial class RestaurantForm : Form
    {
        private readonly RestaurantContoller _restaurantContoller;
        private readonly ApplicationUserController _applicationUserController;
        public RestaurantForm(RestaurantContoller restaurantContoller, ApplicationUserController applicationUserController)
        {
            _restaurantContoller = restaurantContoller;
            _applicationUserController = applicationUserController;
            this.DoubleBuffered = true;
            InitializeComponent();
            LoadData();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Activated += RestaurantForm_Activated;
        }

        private void RestaurantForm_Activated(object sender, EventArgs e)
        {
            LoadData();
        }

        private void RestaurantForm_Load(object sender, EventArgs e)
        {
            LoadData();
            splitContainer19.SplitterWidth = 1;
            splitContainer19.BackColor = splitContainer19.Panel1.BackColor;
            dgvMenu.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvMenu.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        public void LoadData()
        {
            try
            {
                List<MenuItemViewModel> allMenuItems = _restaurantContoller.GetMenuItems();
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

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            OrderForm orderForm = serviceProvider.GetRequiredService<OrderForm>();
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddMenuItemForm addMenuItemForm = serviceProvider.GetRequiredService<AddMenuItemForm>();
            if (addMenuItemForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMenu.SelectedRows.Count > 0)
                {
                    var row = dgvMenu.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (EditRestaurantForm editRestaurantForm = new EditRestaurantForm(_restaurantContoller, id))
                    {
                        if (editRestaurantForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an item to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMenu.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to add the selected items to the recycle?\nIts record including all entries tagged to such item will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvMenu.SelectedRows)
                        {
                            string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                            _restaurantContoller.DeleteItem(id);
                        }
                        LoadData();
                        MessageBox.Show("Successfully added item information to recycle", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an item to recycle.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
    }
}
