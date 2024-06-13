using ESMART_HMS.Domain.Entities;
using System.Collections.Generic;

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
