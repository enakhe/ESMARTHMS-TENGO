using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IReservationRepository
    {
        void AddReservation(Reservation reservation);
        List<ReservationViewModel> GetReservationViewModel();
        void UpdateReservation(Reservation reservation);
        List<ReservationViewModel> GetReservationByPaymentStatus(string roomTypeId, DateTime fromTime, DateTime endTime, string paymentStatus);
        List<ReservationViewModel> GetReservationByRoomTypeAndDate(string roomTypeId, DateTime fromTime, DateTime endTime);
        List<ReservationViewModel> GetReservationByStatuseAndDate(string status, DateTime fromTime, DateTime endTime);
        List<ReservationViewModel> GetReservationByDate(DateTime fromTime, DateTime endTime);
        void DeleteReservation(string id);
        List<ReservationViewModel> GetRecycledReservation();
    }
}
