using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESMART_HMS.Forms.Customers;
using ESMART_HMS.Models;
using ESMART_HMS.Repositories;

namespace ESMART_HMS.Forms.Guests
{
    public partial class CustomersForm : Form
    {
        public CustomersForm()
        {
            InitializeComponent();
            LoadData();
            dgvCustomers.CellDoubleClick += dgvCustomers_CellDoubleClick;
        }

        public void LoadData()
        {
            dgvCustomers.AutoGenerateColumns = false;
            try
            {
                ESMART_HMSDBEntities _db = new ESMART_HMSDBEntities();
                CustomerRepository customerRepository = new CustomerRepository(_db);

                var allCustomers = customerRepository.GetAllCustomers();
                if (allCustomers != null)
                {
                    dgvCustomers.DataSource = _db.Customers.ToList<Customer>();
                    txtCustomerCount.Text = allCustomers.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                string customerId = row.Cells["Id"].Value.ToString();

                using (EditCustomer editCustomerForm = new EditCustomer(customerId))
                {
                    if (editCustomerForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var keyword = txtSearch.Text;
                ESMART_HMSDBEntities _db = new ESMART_HMSDBEntities();
                CustomerRepository customerRepository = new CustomerRepository(_db);

                if (!string.IsNullOrEmpty(keyword))
                {
                    List<Customer> searchedCustomer = customerRepository.SearchCustomer(keyword);
                    dgvCustomers.DataSource = searchedCustomer;
                } else
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

                    using (ViewCustomerForm viewCustomerForm = new ViewCustomerForm(id))
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
                ESMART_HMSDBEntities _db = new ESMART_HMSDBEntities();
                CustomerRepository customerRepository = new CustomerRepository(_db);

                if (dgvCustomers.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected customer?\nIf you delete any customer, its record including all orders tagged to such customer will be deleted as well.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvCustomers.SelectedRows)
                        {
                            string id = row.Cells["Id"].Value.ToString();
                            customerRepository.DeleteCustomer(id);
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
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            if (addCustomerForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
