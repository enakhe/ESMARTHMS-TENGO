using ESMART_HMS.Infrastructure.Data;

namespace ESMART_HMS.Application.UseCases.Reservation
{
    public class UpdateReservationUseCase
    {
        private readonly ReservationRepository _reservationRepository;

        public UpdateReservationUseCase(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public void Execute(Domain.Entities.Reservation reservation)
        {
            _reservationRepository.UpdateReservation(reservation);
        }
    }
}
