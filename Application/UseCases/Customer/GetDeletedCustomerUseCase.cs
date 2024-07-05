using ESMART_HMS.Domain.Interfaces;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Guest
{
    public class GetDeletedGuestUseCase
    {
        private readonly IGuestRepository _customerRepository;

        public GetDeletedGuestUseCase(IGuestRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<ESMART_HMS.Domain.Entities.Guest> Execute()
        {
            return _customerRepository.GetDeletedGuest();
        }
    }
}
