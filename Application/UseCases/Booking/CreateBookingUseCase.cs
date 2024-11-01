using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Booking
{
    public class CreateBookingUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public CreateBookingUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void Execute(ESMART_HMS.Domain.Entities.Booking booking)
        {
            _bookingRepository.AddBooking(booking);
        }
    }
}
