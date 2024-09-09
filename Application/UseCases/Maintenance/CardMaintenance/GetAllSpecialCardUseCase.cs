using ESMART_HMS.Domain.Interfaces.Maintenance;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Maintenance.CardMaintenance
{
    public class GetAllSpecialCardUseCase
    {
        private readonly ICardRepository _cardRepository;

        public GetAllSpecialCardUseCase(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public List<SpecialCardViewModel> Execute()
        {
            return _cardRepository.GetAllSpecialCards();
        }
    }
}
