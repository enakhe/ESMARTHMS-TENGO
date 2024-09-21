using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.FrontDesk.Reservation
{
    public class GetReservationByPaymentStatusUseCase
    {
        private readonly IReservationRepository _reservationRepository;  
        
        public GetReservationByPaymentStatusUseCase(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<ReservationViewModel> Execute(string roomTypeId, DateTime fromTime, DateTime endTime, string paymentStatus)
        {
            return _reservationRepository.GetReservationByPaymentStatus(roomTypeId, fromTime, endTime, paymentStatus);
        }
    }
}
