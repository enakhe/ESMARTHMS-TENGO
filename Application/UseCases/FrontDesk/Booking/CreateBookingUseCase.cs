using ESMART_HMS.Domain.Entities;
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

        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.UpdateBooking(booking);
        }

        public int GetGusteBooking(string id)
        {
            return _bookingRepository.GetGusteBooking(id);
        }
    }
}
