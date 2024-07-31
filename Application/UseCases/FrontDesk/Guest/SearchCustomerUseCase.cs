using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Guest
{
    public class SearchGuestUseCase
    {
        private readonly IGuestRepository _customerRepository;

        public SearchGuestUseCase(IGuestRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<GuestViewModel> Execute(string keyword)
        {
            return _customerRepository.SearchGuest(keyword);
        }
    }
}
