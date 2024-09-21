using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.CardMaintenance
{
    public class DeleteGuestCardUseCase
    {
        private readonly ICardRepository _cardRepository;

        public DeleteGuestCardUseCase(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void Execute(string id)
        {
            _cardRepository.DeleteGuestCard(id);
        }
    }
}
