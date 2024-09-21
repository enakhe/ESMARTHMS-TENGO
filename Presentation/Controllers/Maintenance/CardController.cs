using ESMART_HMS.Application.UseCases.Maintenance.CardMaintenance;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers.Maintenance
{
    public class CardController
    {
        private readonly CreateAuthCardUseCase _createAuthCardUseCase;
        private readonly GetAuthCardByComputerNameUseCase _getAuthCardByComputerNameUseCase;
        private readonly CreateSpecialCardUseCase _createSpecialCardUseCase;
        private readonly GetAllSpecialCardUseCase _getAllSpecialCardUseCase;
        private readonly GetCardByCardNoUseCase _getCardByCardNoUseCase;
        private readonly DeleteCardUseCase _deleteCardUseCase;
        private readonly AddGuestCardUseCase _addGuestCardUseCase;
        private readonly GetGuestCardBybookingIdUseCase _getGuestCardBybookingIdUseCase;
        private readonly DeleteGuestCardUseCase _deleteGuestCardUseCase;

        public CardController(CreateAuthCardUseCase createAuthCardUseCase, GetAuthCardByComputerNameUseCase getAuthCardByComputerNameUseCase, CreateSpecialCardUseCase createSpecialCardUseCase, GetAllSpecialCardUseCase getAllSpecialCardUseCase, GetCardByCardNoUseCase getCardByCardNoUseCase, DeleteCardUseCase deleteCardUseCase, AddGuestCardUseCase addGuestCardUseCase, GetGuestCardBybookingIdUseCase getGuestCardBybookingIdUseCase, DeleteGuestCardUseCase deleteGuestCardUseCase)
        {
            _createAuthCardUseCase = createAuthCardUseCase;
            _getAuthCardByComputerNameUseCase = getAuthCardByComputerNameUseCase;
            _createSpecialCardUseCase = createSpecialCardUseCase;
            _getAllSpecialCardUseCase = getAllSpecialCardUseCase;
            _getCardByCardNoUseCase = getCardByCardNoUseCase;
            _deleteCardUseCase = deleteCardUseCase;
            _addGuestCardUseCase = addGuestCardUseCase;
            _getGuestCardBybookingIdUseCase = getGuestCardBybookingIdUseCase;
            _deleteGuestCardUseCase = deleteGuestCardUseCase;
        }

        public void AddAuthCard(AuthorizationCard authCard)
        {
            _createAuthCardUseCase.Execute(authCard);
        }

        public AuthorizationCard GetAuthCardByComputer(string computerName)
        {
            return _getAuthCardByComputerNameUseCase.Execute(computerName);
        }

        public void AddSpecialCard(SpecialCard card)
        {
            _createSpecialCardUseCase.Execute(card);
        }

        public List<SpecialCardViewModel> GetAllSpecialCards()
        {
            return _getAllSpecialCardUseCase.Execute();
        }

        public SpecialCard GetCardByNo(string cardNo)
        {
            return _getCardByCardNoUseCase.Execute(cardNo);
        }

        public void DeleteCard(string Id)
        {
            _deleteCardUseCase.Execute(Id);
        }

        public void AddGuestCard(GuestCard guestCard)
        {
            _addGuestCardUseCase.Execute(guestCard);
        }

        public GuestCard GetGuestCard(string id)
        {
            return _getGuestCardBybookingIdUseCase.Execute(id);
        }

        public void DeleteGuestCard(string id)
        {
            _deleteGuestCardUseCase.Execute(id);
        }
    }
}
