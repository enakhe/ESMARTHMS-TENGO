using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        List<BookingViewModel> GetAllBookings();
    }
}
