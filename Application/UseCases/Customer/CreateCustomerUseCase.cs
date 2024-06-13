using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Customer
{
    public class CreateCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Execute(ESMART_HMS.Domain.Entities.Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }
    }
}
