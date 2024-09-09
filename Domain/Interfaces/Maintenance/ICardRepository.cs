using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces.Maintenance
{
    public interface ICardRepository
    {
        void AddAuthCard(AuthorizationCard card);
        void AddGuestCard(GuestCard card);
        AuthorizationCard GetAuthCardByComputer(string computerName);
        GuestCard GetGuestCardByBookingId(string id);
        AuthorizationCard GetAuthCardById(string id);
        void AddSpecialCard(SpecialCard card);
        List<SpecialCardViewModel> GetAllSpecialCards();
        SpecialCard GetCardByNo(string cardNo);
        void DeleteCard(string Id);
        void DeleteGuestCard(string Id);
    }
}
