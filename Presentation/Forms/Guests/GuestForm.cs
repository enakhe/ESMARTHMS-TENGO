using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Guests
{
    public partial class GuestForm : Form
    {
        private readonly GuestController _customerController;

        public GuestForm(GuestController customerViewModel)
        {
            InitializeComponent();
            _customerController = customerViewModel;
            LoadData();
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

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var keyword = txtSearch.Text;

                if (!string.IsNullOrEmpty(keyword))
                {
                    List<Guest> searchedGuest = _customerController.SearchGuest(keyword);
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

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGuests.SelectedRows.Count > 0)
                {
                    var row = dgvGuests.SelectedRows[0];
                    string id = row.Cells["Id"].Value.ToString();

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

        private void btnDelete_Click(object sender, EventArgs e)
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

        private void addGuestBtn_Click(object sender, EventArgs e)
        {
            AddGuestForm addGuestForm = new AddGuestForm(_customerController);
            if (addGuestForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dgvGuests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGuests.Rows[e.RowIndex];
                string customerId = row.Cells["Id"].Value.ToString();

                using (EditGuest editGuestForm = new EditGuest(customerId, _customerController))
                {
                    if (editGuestForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }
    }
}
