using ESMART_HMS.Domain.Interfaces;
using System;
using ESMART_HMS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Customer
{
    public class GetAllCustomersUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersUseCase(ICustomerRepository customerRepository)
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
