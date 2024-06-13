using ESMART_HMS.Domain.Interfaces;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Customer
{
    public class SearchCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public SearchCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<ESMART_HMS.Domain.Entities.Customer> Execute(string keyword)
        {
            List<ESMART_HMS.Domain.Entities.Customer> allCustomer = _customerRepository.SearchCustomer(keyword);
            return allCustomer;
        }
    }
}
