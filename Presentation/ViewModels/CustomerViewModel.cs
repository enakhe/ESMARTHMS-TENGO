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

        public ObservableCollection<Customer> Customers { get; set; }

        public CustomerViewModel(GetAllCustomersUseCase getAllCustomersUseCase, CreateCustomerUseCase createCustomerUseCase)
        {
            _getAllCustomersUseCase = getAllCustomersUseCase;
            _createCustomerUseCase = createCustomerUseCase;
            LoadCustomers();
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
    }
}
