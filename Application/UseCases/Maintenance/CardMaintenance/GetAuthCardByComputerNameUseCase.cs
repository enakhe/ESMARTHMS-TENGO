using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;

namespace ESMART_HMS.Application.UseCases.Maintenance.CardMaintenance
{
    public class GetAuthCardByComputerNameUseCase
    {
        private readonly ICardRepository _cardRepository;

        public GetAuthCardByComputerNameUseCase(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public AuthorizationCard Execute(string computerName)
        {
            return _cardRepository.GetAuthCardByComputer(computerName);
        }
    }
}
