using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.CardMaintenance
{
    public class CreateSpecialCardUseCase
    {
        private readonly ICardRepository _cardRepository;

        public CreateSpecialCardUseCase(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void Execute(SpecialCard card)
        {
            _cardRepository.AddSpecialCard(card);
        }
    }
}
