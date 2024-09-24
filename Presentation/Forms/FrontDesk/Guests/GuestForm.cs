using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using ESMART_HMS.Presentation.Controllers.Maintenance;
using ESMART_HMS.Presentation.Middleware;
using ESMART_HMS.Presentation.Sessions;
using ESMART_HMS.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Web.Configuration;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Guests
{
    public partial class GuestForm : Form
    {
        private readonly GuestController _customerController;
        private PrintDocument printDocument1 = new PrintDocument();
        private string documentTitle = "Guest List";
        private readonly ApplicationUserController _applicationUserController;
        private readonly SystemSetupController _systemSetupController;

        public GuestForm(GuestController customerViewModel, ApplicationUserController applicationUserController, SystemSetupController systemSetupController)
        {
            _customerController = customerViewModel;
            _applicationUserController = applicationUserController;
            _systemSetupController = systemSetupController;
            InitializeComponent();
            LoadData();
            ApplyAuthorization();
            printDocument1.DefaultPageSettings.Landscape = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
        }

        private void ApplyAuthorization()
        {
            ApplicationUser user = _applicationUserController.GetApplicationUserById(AuthSession.CurrentUser.Id);
            AuthorizationMiddleware.Protect(user, btnDelete, "SuperAdmin");
        }

        public void LoadData()
        {
            dgvGuests.AutoGenerateColumns = false;
            try
            {
                var allGuests = _customerController.LoadGuests();
                if (allGuests != null)
                {
                    dgvGuests.DataSource = allGuests;
                    txtGuestCount.Text = allGuests.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                var keyword = txtSearch.Text;

                if (!string.IsNullOrEmpty(keyword))
                {
                    List<GuestViewModel> searchedGuest = _customerController.SearchGuest(keyword);
                    dgvGuests.DataSource = searchedGuest;
                }
                else
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            AddGuestForm addGuestForm = serviceProvider.GetRequiredService<AddGuestForm>();
            if (addGuestForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGuests.SelectedRows.Count > 0)
                {
                    var row = dgvGuests.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (EditGuest editGuestForm = new EditGuest(id, _customerController))
                    {
                        if (editGuestForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a guest to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGuests.SelectedRows.Count > 0)
                {
                    var row = dgvGuests.SelectedRows[0];
                    string id = row.Cells["idDataGridViewTextBoxColumn"].Value.ToString();

                    using (ViewGuestForm viewGuestForm = new ViewGuestForm(id, _customerController))
                    {
                        if (viewGuestForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void btnDeleteG_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGuests.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected customer?\nIf you delete any customer, its record including all orders tagged to such customer will be added to the recycle bin as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvGuests.SelectedRows)
                        {
                            string id = row.Cells["Id"].Value.ToString();
                            _customerController.DeleteGuest(id);
                        }
                        LoadData();
                        MessageBox.Show("Successfully deleted customer information", "Success", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void GuestForm_Load(object sender, EventArgs e)
        {
            splitContainer5.SplitterWidth = 1;
            splitContainer5.BackColor = splitContainer5.Panel1.BackColor;
        }
    }
}
