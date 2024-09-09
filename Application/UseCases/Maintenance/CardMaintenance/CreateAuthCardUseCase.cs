using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.CardMaintenance
{
    public class CreateAuthCardUseCase
    {
        private readonly ICardRepository _cardRepository;

        public CreateAuthCardUseCase(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void Execute(AuthorizationCard authCard)
        {
            _cardRepository.AddAuthCard(authCard);
        }
    }
}
