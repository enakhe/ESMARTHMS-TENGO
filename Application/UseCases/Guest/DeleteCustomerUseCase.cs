using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Guest
{
    public class DeleteGuestUseCase
    {
        private readonly IGuestRepository _customerRepository;

        public DeleteGuestUseCase(IGuestRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Execute(string Id)
        {
            _customerRepository.DeleteGuest(Id);
        }
    }
}
