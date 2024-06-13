using ESMART_HMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(string Id);
        void EditCustomer(Customer customer);
        void DeleteCustomer(string Id);
        List<Customer> SearchCustomer(string keyword);
    }
}
