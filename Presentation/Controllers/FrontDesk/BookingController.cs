using ESMART_HMS.Application.UseCases.Booking;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers
{
    public class BookingController
    {
        private readonly CreateBookingUseCase _createBookingUseCase;
        private readonly GetAllBookingsUseCase _getAllBookingsUseCase;

        public BookingController(CreateBookingUseCase createBookingUseCase, GetAllBookingsUseCase getAllBookingsUseCase)
        {
            _createBookingUseCase = createBookingUseCase;
            _getAllBookingsUseCase = getAllBookingsUseCase;
        }

        public void AddBooking(Booking booking)
        {
            _createBookingUseCase.Execute(booking);
        }

        public List<BookingViewModel> GetAllBookings()
        {
            return _getAllBookingsUseCase.Execute();
        }
    }
}
