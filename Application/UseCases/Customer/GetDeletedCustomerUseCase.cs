using ESMART_HMS.Domain.Interfaces;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Customer
{
    public class GetDeletedCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public GetDeletedCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<ESMART_HMS.Domain.Entities.Customer> Execute()
        {
            return _customerRepository.GetDeletedCustomer();
        }
    }
}
