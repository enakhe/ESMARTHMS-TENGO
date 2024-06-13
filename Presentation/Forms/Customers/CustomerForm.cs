using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ESMART_HMS.Presentation.Forms.Customers
{
    public partial class CustomerForm : Form
    {
        private readonly CustomerViewModel _customerViewModel;

        public CustomerForm(CustomerViewModel customerViewModel)
        {
            InitializeComponent();
            _customerViewModel = customerViewModel;
            LoadData();
        }

        public void LoadData()
        {
            dgvCustomers.AutoGenerateColumns = false;
            try
            {
                var allCustomers = _customerViewModel.LoadCustomers();
                if (allCustomers != null)
                {
                    dgvCustomers.DataSource = allCustomers;
                    txtCustomerCount.Text = allCustomers.Count.ToString();
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
                    List<Customer> searchedCustomer = _customerViewModel.SearchCustomer(keyword);
                    dgvCustomers.DataSource = searchedCustomer;
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
                if (dgvCustomers.SelectedRows.Count > 0)
                {
                    var row = dgvCustomers.SelectedRows[0];
                    string id = row.Cells["Id"].Value.ToString();

                    using (ViewCustomerForm viewCustomerForm = new ViewCustomerForm(id, _customerViewModel))
                    {
                        if (viewCustomerForm.ShowDialog() == DialogResult.OK)
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
                if (dgvCustomers.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected customer?\nIf you delete any customer, its record including all orders tagged to such customer will be deleted as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvCustomers.SelectedRows)
                        {
                            string id = row.Cells["Id"].Value.ToString();
                            _customerViewModel.DeleteCustomer(id);
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

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm(_customerViewModel);
            if (addCustomerForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                string customerId = row.Cells["Id"].Value.ToString();

                using (EditCustomer editCustomerForm = new EditCustomer(customerId, _customerViewModel))
                {
                    if (editCustomerForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }
    }
}
