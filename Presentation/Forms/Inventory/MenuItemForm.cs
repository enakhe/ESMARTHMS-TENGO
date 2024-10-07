using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Utils;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Inventory;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Middleware;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Inventory
{
    public partial class MenuItemForm : Form
    {
        private readonly InventoryController _inventoryController;
        private bool _continueRunning = true;

        private readonly ApplicationUserController _applicationUserController;
        private readonly SystemSetupController _systemSetupController;
        public MenuItemForm(InventoryController inventoryController, ApplicationUserController applicationUserController, SystemSetupController systemSetupController)
        {
            _inventoryController = inventoryController;
            _applicationUserController = applicationUserController;
            _systemSetupController = systemSetupController;
            InitializeComponent();
            ApplyAuthorization();
            StartBackgroundTask();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            LoadInventoryData();
        }

        public async void StartBackgroundTask()
        {
            await Task.Run(() =>
            {
                while (_continueRunning)
                {
                    ApplyAuthorization();
                    Task.Delay(1000).Wait();
                }
            });
        }

        private void ApplyAuthorization()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ApplyAuthorization));
                return;
            }
            List<string> roles = new List<string> { "Admin", "SuperAdmin", "Manager" };
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            AuthorizationMiddleware.ProtectControl(user, btnDelete, roles);
        }

        private void MenuItemForm_Load(object sender, EventArgs e)
        {
            splitContainer19.SplitterWidth = 1;
            splitContainer19.BackColor = splitContainer19.Panel1.BackColor;
            dgvItem.Font = new System.Drawing.Font("Segoe UI", 10);
            dgvItem.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        public void LoadInventoryData()
        {
            try
            {
                List<InventoryViewModel> inventoryList = _inventoryController.GetInventoryViewModels();
                foreach (InventoryViewModel inventoryViewModel in inventoryList)
                {
                    inventoryViewModel.SellingPrice = FormHelper.FormatNumberWithCommas(decimal.Parse(inventoryViewModel.SellingPrice));
                    inventoryViewModel.CostPrice = FormHelper.FormatNumberWithCommas(decimal.Parse(inventoryViewModel.CostPrice));

                    inventoryViewModel.DateCreated = FormHelper.FormatDateTimeWithSuffix(inventoryViewModel.DateCreated);
                    inventoryViewModel.DateModified = FormHelper.FormatDateTimeWithSuffix(inventoryViewModel.DateModified);
                }
                dgvItem.DataSource = inventoryList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddInventoryForm addInventoryForm = serviceProvider.GetRequiredService<AddInventoryForm>();
            if (addInventoryForm.ShowDialog() == DialogResult.OK)
            {
                LoadInventoryData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItem.SelectedRows.Count > 0)
                {
                    var row = dgvItem.SelectedRows[0];
                    string id = row.Cells["dataGridViewTextBoxColumn1"].Value.ToString();

                    using (EditMenuItemForm editMenuItemForm = new EditMenuItemForm(_inventoryController, id))
                    {
                        if (editMenuItemForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadInventoryData();
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

        public void ImportItemsFromExcel(string filePath)
        {
            List<Domain.Entities.MenuItem> items = new List<Domain.Entities.MenuItem>();
            FileInfo fileInfo = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    Random random = new Random();
                    Domain.Entities.MenuItem item = new Domain.Entities.MenuItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        MenuItemId = "MNU" + random.Next(1000, 5000),
                        Barcode = worksheet.Cells[row, 1].Text,
                        ItemName = worksheet.Cells[row, 2].Text,
                        Category = worksheet.Cells[row, 3].Text,
                        CostPrice = decimal.Parse(worksheet.Cells[row, 4].Text),
                        SellingPrice = decimal.Parse(worksheet.Cells[row, 5].Text),
                        Quantity = int.Parse(worksheet.Cells[row, 6].Text),
                        Type = worksheet.Cells[row, 7].Text,
                        Measurement = worksheet.Cells[row, 8].Text,
                        Section = worksheet.Cells[row, 9].Text,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = AuthSession.CurrentUser.Id,
                        ApplicationUser = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id),
                        IsTrashed = false,
                    };
                    _inventoryController.AddItem(item);

                    Domain.Entities.Inventory inventory = new Domain.Entities.Inventory()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CreatedBy = AuthSession.CurrentUser.Id,
                        ApplicationUser = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id),
                        CurrentStock = item.Quantity,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        InitialStock = item.Quantity,
                        LowStockThreshold = int.Parse(worksheet.Cells[row, 10].Text),
                        MenuItemId = item.Id,
                        MenuItem = item,
                        IsTrashed = false
                    };
                    _inventoryController.AddInventory(inventory);
                    LoadInventoryData();
                }
            }
        }

        public void ExportTemplate(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo fileInfo = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("MenuItemsTemplate");

                worksheet.Cells[1, 1].Value = "Barcode";
                worksheet.Cells[1, 2].Value = "ItemName";
                worksheet.Cells[1, 3].Value = "Category";
                worksheet.Cells[1, 4].Value = "CostPrice";
                worksheet.Cells[1, 5].Value = "SellingPrice";
                worksheet.Cells[1, 6].Value = "Quantity";
                worksheet.Cells[1, 7].Value = "Type";
                worksheet.Cells[1, 8].Value = "Measurement";
                worksheet.Cells[1, 9].Value = "Section";
                worksheet.Cells[1, 10].Value = "LowStockThreshold";
                package.Save();
            }

            MessageBox.Show("Template exported successfully.", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnSheet_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.Title = "Select an Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    ImportItemsFromExcel(filePath);
                    MessageBox.Show($"Items imported successfully.", "Import Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Excel Template";
                saveFileDialog.FileName = "MenuItemsTemplate.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    ExportTemplate(filePath);
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItem.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected item?\nIf you delete any item, its record including all orders tagged to such item will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvItem.SelectedRows)
                        {
                            string id = row.Cells["dataGridViewTextBoxColumn1"].Value.ToString();
                            _inventoryController.DeleteInventory(id);
                            var inventory = _inventoryController.GetInventoryById(id);
                            CompanyInformation foundCompany = _systemSetupController.GetCompanyInfo();
                            string guestString = $"Id = {inventory.Id}\n" +
                                $"Item Name = {inventory.MenuItem.ItemName}\n" +
                                $"Cost Price = {inventory.MenuItem.CostPrice}\n" +
                                $"Selling Price = {inventory.MenuItem.SellingPrice}\n" +
                                $"Category = {inventory.MenuItem.Category}\n" +
                                $"Initial Stock = {inventory.InitialStock}\n" +
                                $"Current Stock = {inventory.CurrentStock}\n" +
                                $"Low Stock Threshold = {inventory.LowStockThreshold}\n" +
                                $"Created By = {inventory.ApplicationUser.FullName}\n";
                            if (foundCompany != null)
                            {
                                if (foundCompany.Email != null)
                                {
                                    await EmailHelper.SendEmail(foundCompany.Email, "Item Recycled", guestString);
                                }
                            }
                        }
                        LoadInventoryData();
                        MessageBox.Show("Successfully deleted item information", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an item to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
