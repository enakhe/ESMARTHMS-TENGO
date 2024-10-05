using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.FrontDesk.Reservation
{
    public class GetReservationByRoomTypeAndDateUseCase
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationByRoomTypeAndDateUseCase(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<ReservationViewModel> Execute(string roomTypeId, DateTime fromTime, DateTime endTime)
        {
            return _reservationRepository.GetReservationByRoomTypeAndDate(roomTypeId, fromTime, endTime);
        }
    }
}
