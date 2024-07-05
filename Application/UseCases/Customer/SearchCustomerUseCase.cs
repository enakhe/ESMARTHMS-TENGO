using ESMART_HMS.Domain.Interfaces;
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

        public List<ESMART_HMS.Domain.Entities.Guest> Execute(string keyword)
        {
            List<ESMART_HMS.Domain.Entities.Guest> allGuest = _customerRepository.SearchGuest(keyword);
            return allGuest;
        }
    }
}
