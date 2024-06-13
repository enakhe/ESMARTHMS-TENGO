using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Customer
{
    public class GetCustomerByIdUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ESMART_HMS.Domain.Entities.Customer Execute(string Id)
        {
            ESMART_HMS.Domain.Entities.Customer customer = _customerRepository.GetCustomerById(Id);
            return customer;
        }
    }
}
