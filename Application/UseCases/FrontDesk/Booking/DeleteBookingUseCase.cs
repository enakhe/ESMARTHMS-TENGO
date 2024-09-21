using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.FrontDesk.booking
{
    public class DeletebookingUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public DeletebookingUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void Execute(Domain.Entities.Booking booking)
        {
            _bookingRepository.DeleteBooking(booking);
        }
    }
}
