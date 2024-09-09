using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Maintenance.CardMaintenance
{
    public class GetGuestCardByBookingIdUseCase
    {
        private readonly ICardRepository _cardRepository;

        public GetGuestCardByBookingIdUseCase(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public GuestCard Execute(string id)
        {
            return _cardRepository.GetGuestCardByBookingId(id);
        }
    }
}
