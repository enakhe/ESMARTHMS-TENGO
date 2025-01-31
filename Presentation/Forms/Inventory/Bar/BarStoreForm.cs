﻿using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Forms.Bar;
using ESMART_HMS.Presentation.Forms.Bar.BarStore;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Store.BarStore
{
    public partial class BarStoreForm : Form
    {
        private readonly BarItemController _barItemController;
        private readonly ApplicationUserController _applicationUserController;
        public BarStoreForm(BarItemController barItemController, ApplicationUserController applicationUserController)
        {
            _barItemController = barItemController;
            _applicationUserController = applicationUserController;
            this.DoubleBuffered = true;
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Activated += BarStoreForm_Activated;
        }

        private void BarStoreForm_Load(object sender, EventArgs e)
        {
            LoadData();
            splitContainer19.SplitterWidth = 1;
            splitContainer19.BackColor = splitContainer19.Panel1.BackColor;
            dgvBarStore.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvBarStore.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        public void LoadData()
        {
            try
            {
                List<BarItemViewModel> allBarItems = _barItemController.GetAllBarItem();
                if (allBarItems != null)
                {
                    foreach (var items in allBarItems)
                    {
                        FormHelper.TryConvertStringToDecimal(items.CostPrice, out decimal costPrice);
                        FormHelper.TryConvertStringToDecimal(items.SellingPrice, out decimal sellingPrice);

                        items.CostPrice = FormHelper.FormatNumberWithCommas(costPrice);
                        items.SellingPrice = FormHelper.FormatNumberWithCommas(sellingPrice);

                        items.DateCreated = FormHelper.FormatDateTimeWithSuffix(items.DateCreated);
                        items.DateModified = FormHelper.FormatDateTimeWithSuffix(items.DateModified);

                        if (int.Parse(items.Quantity) <= int.Parse(items.LowStock))
                        {
                            quantityDataGridViewTextBoxColumn.DefaultCellStyle.BackColor = Color.Red;
                            quantityDataGridViewTextBoxColumn.DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                    dgvBarStore.DataSource = allBarItems;
                    txtCount.Text = allBarItems.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void DataGridViewRooms_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBarStore.Columns[e.ColumnIndex].Name == "quantityDataGridViewTextBoxColumn")
            {
                var cell = dgvBarStore.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null && cell.Value.ToString() == "Vacant")
                {
                    cell.Style.BackColor = System.Drawing.Color.Green;
                    cell.Style.ForeColor = System.Drawing.Color.White;
                }
                else if (cell.Value != null && cell.Value.ToString() == "Reserved")
                {
                    cell.Style.BackColor = System.Drawing.Color.Yellow;
                    cell.Style.ForeColor = System.Drawing.Color.Black;
                }
                else if (cell.Value != null && cell.Value.ToString() == "CheckedIn")
                {
                    cell.Style.BackColor = System.Drawing.Color.Blue;
                    cell.Style.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    cell.Style.BackColor = System.Drawing.Color.Red;
                    cell.Style.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddBarItemForm addBarItemForm = serviceProvider.GetRequiredService<AddBarItemForm>();
            if (addBarItemForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBarStore.SelectedRows.Count > 0)
                {
                    var row = dgvBarStore.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (EditBarItemForm editBarItemForm = new EditBarItemForm(_barItemController, id))
                    {
                        if (editBarItemForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a floor to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (dgvBarStore.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to add the selected itmems to the recycle?\nIts record including all entries tagged to such item will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvBarStore.SelectedRows)
                        {
                            string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                            _barItemController.DeleteBarItem(id);
                        }
                        LoadData();
                        MessageBox.Show("Successfully added building information to recycle", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a builing to recycle.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BarStoreForm_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
