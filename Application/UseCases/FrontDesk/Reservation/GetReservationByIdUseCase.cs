using ESMART_HMS.Infrastructure.Data;

namespace ESMART_HMS.Application.UseCases.Reservation
{
    public class GetReservationByIdUseCase
    {
        private readonly ReservationRepository _reservationRepository;

        public GetReservationByIdUseCase(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public ESMART_HMS.Domain.Entities.Reservation Execute(string Id)
        {
            return _reservationRepository.GetReservationById(Id);
        }
    }
}
