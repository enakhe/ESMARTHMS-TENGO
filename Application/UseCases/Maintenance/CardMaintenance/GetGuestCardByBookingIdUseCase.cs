using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.CardMaintenance
{
    public class GetGuestCardBybookingIdUseCase
    {
        private readonly ICardRepository _cardRepository;

        public GetGuestCardBybookingIdUseCase(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public GuestCard Execute(string id)
        {
            return _cardRepository.GetGuestCardBybookingId(id);
        }
    }
}
