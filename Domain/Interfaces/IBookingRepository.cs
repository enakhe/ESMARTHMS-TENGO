using ESMART_HMS.Domain.Entities;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
    }
}
