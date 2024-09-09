using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Maintenance.CardMaintenance
{
    public class GetCardByCardNoUseCase
    {
        private readonly ICardRepository _cardRepository;

        public GetCardByCardNoUseCase(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public SpecialCard Execute(string cardNo)
        {
            return _cardRepository.GetCardByNo(cardNo);
        }
    }
}
