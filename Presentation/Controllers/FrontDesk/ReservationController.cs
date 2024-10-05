using ESMART_HMS.Application.UseCases.FrontDesk.Reservation;
using ESMART_HMS.Application.UseCases.Reservation;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers
{
    public class ReservationController
    {
        private readonly CreateReservationUseCase _addReservationUseCase;
        private readonly GetAllReservationUseCase _allReservationUseCase;
        private readonly GetReservationByIdUseCase _getReservationByIdUseCase;
        private readonly UpdateReservationUseCase _updateReservationUseCase;
        private readonly GetReservationByPaymentStatusUseCase _getReservationByPaymentStatusUseCase;
        private readonly GetReservationByRoomTypeAndDateUseCase _getReservationByRoomTypeAndDateUseCase;
        private readonly GetReservationByStatuseAndDateUseCase _getReservationByStatuseAndDateUseCase;
        private readonly GetReservationByDateUseCase _getReservationByDateUseCase;

        public ReservationController(CreateReservationUseCase addReservationUseCase, GetAllReservationUseCase allReservationUseCase, GetReservationByIdUseCase getReservationByIdUseCase, UpdateReservationUseCase updateReservationUseCase, GetReservationByPaymentStatusUseCase getReservationByPaymentStatusUseCase, GetReservationByRoomTypeAndDateUseCase getReservationByRoomTypeAndDateUseCase, GetReservationByStatuseAndDateUseCase getReservationByStatuseAndDateUseCase, GetReservationByDateUseCase getReservationByDateUseCase)
        {
            _addReservationUseCase = addReservationUseCase;
            _allReservationUseCase = allReservationUseCase;
            _getReservationByIdUseCase = getReservationByIdUseCase;
            _updateReservationUseCase = updateReservationUseCase;
            _getReservationByPaymentStatusUseCase = getReservationByPaymentStatusUseCase;
            _getReservationByRoomTypeAndDateUseCase = getReservationByRoomTypeAndDateUseCase;
            _getReservationByStatuseAndDateUseCase = getReservationByStatuseAndDateUseCase;
            _getReservationByDateUseCase = getReservationByDateUseCase;
        }

        public void AddReservation(Reservation reservation)
        {
            _addReservationUseCase.Execute(reservation);
        }

        public IList<ReservationViewModel> GetAllReservation()
        {
            return _allReservationUseCase.Execute();
        }

        public Reservation GetReservationById(string Id)
        {
            return _getReservationByIdUseCase.Execute(Id);
        }

        public void UpdateReservation(Reservation reservation)
        {
            _updateReservationUseCase.Execute(reservation);
        }

        public List<ReservationViewModel> GetReservationByPaymentStatus(string roomTypeId, DateTime fromTime, DateTime endTime, string paymentStatus)
        {
            return _getReservationByPaymentStatusUseCase.Execute(roomTypeId, fromTime, endTime, paymentStatus);
        }

        public List<ReservationViewModel> GetReservationByRoomTypeAndDate(string roomTypeId, DateTime fromTime, DateTime endTime)
        {
            return _getReservationByRoomTypeAndDateUseCase.Execute(roomTypeId, fromTime, endTime);
        }

        public List<ReservationViewModel> GetReservationByStatusAndDate(string status, DateTime fromTime, DateTime endTime)
        {
            return _getReservationByStatuseAndDateUseCase.Execute(status, fromTime, endTime);
        }

        public List<ReservationViewModel> GetReservationDate(DateTime fromTime, DateTime endTime)
        {
            return _getReservationByDateUseCase.Execute(fromTime, endTime);
        }

        public void DeleteReservation(string id)
        {
            _updateReservationUseCase.DeleteReservation(id);
        }

        public List<ReservationViewModel> GetRecycledReservation()
        {
            return _allReservationUseCase.GetRecycledReservation();
        }
    }
}
