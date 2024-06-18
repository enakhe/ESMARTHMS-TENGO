using ESMART_HMS.Domain.Interfaces;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Customer
{
    public class GetAllCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<ESMART_HMS.Domain.Entities.Customer> Execute()
        {
            var allCustomer = _customerRepository.GetAllCustomers();
            return allCustomer;
        }
    }
}
