using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IReservationRepository
    {
        void AddReservation(Reservation reservation);
        List<ReservationViewModel> GetReservationViewModel();
        void UpdateReservation(Reservation reservation);
    }
}
