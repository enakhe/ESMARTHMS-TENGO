using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.FrontDesk.Reservation
{
    public class GetReservationByDateUseCase
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationByDateUseCase(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<ReservationViewModel> Execute(DateTime fromTime, DateTime endTime)
        {
            return _reservationRepository.GetReservationByDate(fromTime, endTime);
        }
    }
}
