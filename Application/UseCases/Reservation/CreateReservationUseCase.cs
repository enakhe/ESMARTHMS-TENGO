using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Reservation
{
    public class CreateReservationUseCase
    {
        private readonly IReservationRepository _reservationRepository;

        public CreateReservationUseCase(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public void Execute(ESMART_HMS.Domain.Entities.Reservation reservation)
        {
            _reservationRepository.AddReservation(reservation);
        }
    }
}
