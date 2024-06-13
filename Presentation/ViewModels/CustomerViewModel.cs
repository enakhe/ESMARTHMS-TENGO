using ESMART_HMS.Application.UseCases.Customer;
using ESMART_HMS.Domain.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ESMART_HMS.Presentation.ViewModels
{
    public class CustomerViewModel
    {
        private readonly GetAllCustomersUseCase _getAllCustomersUseCase;
        private readonly CreateCustomerUseCase _createCustomerUseCase;
        private readonly UpdateCustomerUseCase _updateCustomerUseCase;
        private readonly GetCustomerByIdUseCase _getCustomerByIdUseCase;
        private readonly DeleteCustomerUseCase _deleteCustomerUseCase;

        public ObservableCollection<Customer> Customers { get; set; }

        public CustomerViewModel(GetAllCustomersUseCase getAllCustomersUseCase, CreateCustomerUseCase createCustomerUseCase, UpdateCustomerUseCase updateCustomerUseCase, GetCustomerByIdUseCase getCustomerByIdUseCase, DeleteCustomerUseCase deleteCustomerUseCase)
        {
            _getAllCustomersUseCase = getAllCustomersUseCase;
            _createCustomerUseCase = createCustomerUseCase;
            LoadCustomers();
            _updateCustomerUseCase = updateCustomerUseCase;
            _getCustomerByIdUseCase = getCustomerByIdUseCase;
            _deleteCustomerUseCase = deleteCustomerUseCase;
        }

        public List<Customer> LoadCustomers()
        {
            var allCustomer = _getAllCustomersUseCase.Execute();
            return allCustomer;
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
    }
}
