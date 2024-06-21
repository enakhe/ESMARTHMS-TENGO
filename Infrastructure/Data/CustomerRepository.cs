using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public CustomerRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                MessageBox.Show("Successfully added customer information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                List<Customer> allCustomers = _db.Customers.Where(c => c.IsTrashed != true).ToList<Customer>();
                return allCustomers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public Customer GetCustomerById(string Id)
        {
            try
            {
                var Customer = _db.Customers.FirstOrDefault(c => c.Id == Id);
                if (Customer == null)
                {
                    MessageBox.Show("Customer not found", "Not Found", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    return Customer;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                _db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                MessageBox.Show("Successfully edited customer information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public void DeleteCustomer(string Id)
        {
            try
            {
                var customer = _db.Customers.FirstOrDefault(c => c.Id == Id);
                if (customer != null)
                {
                    customer.IsTrashed = true;
                    _db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Customer not found", "Not Found", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<Customer> SearchCustomer(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Keyword cannot be empty", "Invalid Entry", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }

                List<Customer> searchCustomer = _db.Customers.Where(c => c.FullName.Contains(keyword) || c.Email.Contains(keyword) || c.PhoneNumber.Contains(keyword) || c.Street.Contains(keyword) || c.City.Contains(keyword) || c.State.Contains(keyword) || c.Country.Contains(keyword) || c.CustomerId.Contains(keyword) || c.Company.Contains(keyword)).ToList();

                return searchCustomer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

            return null;
        }

        public List<Customer> GetDeletedCustomer()
        {
            try
            {
                return _db.Customers.Where(c => c.IsTrashed == true).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
