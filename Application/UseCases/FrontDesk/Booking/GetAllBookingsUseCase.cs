using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.booking
{
    public class GetAllbookingsUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public GetAllbookingsUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<BookingViewModel> Execute()
        {
            return _bookingRepository.GetAllBookings();
        }

        public List<BookingViewModel> GetRecycledBooking()
        {
            return _bookingRepository.GetRecycledBookings();
        }
    }
}
