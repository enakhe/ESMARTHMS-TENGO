using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Guest
{
    public class CreateGuestUseCase
    {
        private readonly IGuestRepository _customerRepository;

        public CreateGuestUseCase(IGuestRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Execute(ESMART_HMS.Domain.Entities.Guest customer)
        {
            _customerRepository.AddGuest(customer);
        }
    }
}
