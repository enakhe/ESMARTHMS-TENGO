using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.booking
{
    public class CreatebookingUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public CreatebookingUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void Execute(ESMART_HMS.Domain.Entities.Booking booking)
        {
            _bookingRepository.AddBooking(booking);
        }
    }
}
