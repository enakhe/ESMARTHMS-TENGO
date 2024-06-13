using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Customer
{
    public class UpdateCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Execute(ESMART_HMS.Domain.Entities.Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }
    }
}
