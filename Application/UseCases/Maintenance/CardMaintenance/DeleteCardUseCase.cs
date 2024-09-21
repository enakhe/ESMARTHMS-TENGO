using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.CardMaintenance
{
    public class DeleteCardUseCase
    {
        private readonly ICardRepository _cardRepository;

        public DeleteCardUseCase(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void Execute(string Id)
        {
            _cardRepository.DeleteCard(Id);
        }

    }
}
