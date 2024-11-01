using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Guest
{
    public class UpdateGuestUseCase
    {
        private readonly IGuestRepository _customerRepository;

        public UpdateGuestUseCase(IGuestRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Execute(ESMART_HMS.Domain.Entities.Guest customer)
        {
            _customerRepository.UpdateGuest(customer);
        }
    }
}
