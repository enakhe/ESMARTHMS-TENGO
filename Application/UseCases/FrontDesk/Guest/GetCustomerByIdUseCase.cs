using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Guest
{
    public class GetGuestByIdUseCase
    {
        private readonly IGuestRepository _customerRepository;

        public GetGuestByIdUseCase(IGuestRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ESMART_HMS.Domain.Entities.Guest Execute(string Id)
        {
            return _customerRepository.GetGuestById(Id);
        }
    }
}
