using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IGuestRepository
    {
        void AddGuest(Guest customer);
        List<GuestViewModel> GetAllGuests();
        Guest GetGuestById(string Id);
        void UpdateGuest(Guest customer);
        void DeleteGuest(string Id);
        List<Guest> SearchGuest(string keyword);
        List<Guest> GetDeletedGuest();
    }
}
