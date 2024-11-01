using ESMART_HMS.Infrastructure.Data;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

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
