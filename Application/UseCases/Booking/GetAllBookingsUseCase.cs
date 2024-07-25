using ESMART_HMS.Infrastructure.Data;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Booking
{
    public class GetAllBookingsUseCase
    {
        private readonly BookingRepository _bookingRepository;

        public GetAllBookingsUseCase(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<BookingViewModel> Execute()
        {
            return _bookingRepository.GetAllBookings();
        }
    }
}
