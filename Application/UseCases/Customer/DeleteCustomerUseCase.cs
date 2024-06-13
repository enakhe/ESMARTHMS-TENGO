using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Customer
{
    public class DeleteCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Execute(string Id)
        {
            _customerRepository.DeleteCustomer(Id);
        }
    }
}
