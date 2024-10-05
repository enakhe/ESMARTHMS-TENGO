using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.FrontDesk.Reservation
{
    public class GetReservationByStatuseAndDateUseCase
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationByStatuseAndDateUseCase(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<ReservationViewModel> Execute(string status, DateTime fromTime, DateTime endTime)
        {
            return _reservationRepository.GetReservationByStatuseAndDate(status, fromTime, endTime);
        }
    }
}
