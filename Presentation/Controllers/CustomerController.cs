using ESMART_HMS.Application.UseCases.Customer;
using ESMART_HMS.Domain.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ESMART_HMS.Presentation.Controllers
{
    public class CustomerController
    {
        private readonly GetAllCustomerUseCase _getAllCustomersUseCase;
        private readonly CreateCustomerUseCase _createCustomerUseCase;
        private readonly UpdateCustomerUseCase _updateCustomerUseCase;
        private readonly GetCustomerByIdUseCase _getCustomerByIdUseCase;
        private readonly DeleteCustomerUseCase _deleteCustomerUseCase;
        private readonly SearchCustomerUseCase _searchCustomerUseCase;
        private readonly GetDeletedCustomerUseCase _getDeletedCustomerUseCase;

        public ObservableCollection<Customer> Customers { get; set; }

        public CustomerController(GetAllCustomerUseCase getAllCustomersUseCase, CreateCustomerUseCase createCustomerUseCase, UpdateCustomerUseCase updateCustomerUseCase, GetCustomerByIdUseCase getCustomerByIdUseCase, DeleteCustomerUseCase deleteCustomerUseCase, SearchCustomerUseCase searchCustomerUseCase, GetDeletedCustomerUseCase getDeletedCustomerUseCase)
        {
            _getAllCustomersUseCase = getAllCustomersUseCase;
            _createCustomerUseCase = createCustomerUseCase;
            _updateCustomerUseCase = updateCustomerUseCase;
            _getCustomerByIdUseCase = getCustomerByIdUseCase;
            _deleteCustomerUseCase = deleteCustomerUseCase;
            _searchCustomerUseCase = searchCustomerUseCase;
            _getDeletedCustomerUseCase = getDeletedCustomerUseCase;

            LoadCustomers();
        }

        public List<Customer> LoadCustomers()
        {
            return _getAllCustomersUseCase.Execute();
        }

        public void AddCustomer(Customer customer)
        {
            _createCustomerUseCase.Execute(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _updateCustomerUseCase.Execute(customer);
        }

        public Customer GetCustomerById(string Id)
        {
            Customer customer = _getCustomerByIdUseCase.Execute(Id);
            return customer;
        }

        public void DeleteCustomer(string Id)
        {
            _deleteCustomerUseCase.Execute(Id);
        }

        public List<ESMART_HMS.Domain.Entities.Customer> SearchCustomer(string keyword)
        {
            return _searchCustomerUseCase.Execute(keyword);
        }
        public List<ESMART_HMS.Domain.Entities.Customer> GetDeletedCustomer()
        {
            return _getDeletedCustomerUseCase.Execute();
        }
    }
}
