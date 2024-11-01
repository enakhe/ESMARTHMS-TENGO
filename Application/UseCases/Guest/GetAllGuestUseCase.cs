using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Guest
{
    public class GetAllGuestUseCase
    {
        private readonly IGuestRepository _customerRepository;

        public GetAllGuestUseCase(IGuestRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<GuestViewModel> Execute()
        {
            var allGuest = _customerRepository.GetAllGuests();
            return allGuest;
        }
    }
}
