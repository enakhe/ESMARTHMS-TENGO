using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.CardMaintenance
{
    public class AddGuestCardUseCase
    {
        private readonly ICardRepository _cardRepository;

        public AddGuestCardUseCase(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void Execute(GuestCard card)
        {
            _cardRepository.AddGuestCard(card);
        }
    }
}
