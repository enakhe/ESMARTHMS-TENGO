using ESMART_HMS.Infrastructure.Data;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Reservation
{
    public class GetAllReservationUseCase
    {
        private readonly ReservationRepository _reservationRepository;

        public GetAllReservationUseCase(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<ReservationViewModel> Execute()
        {
            return _reservationRepository.GetReservationViewModel();
        }
    }
}
