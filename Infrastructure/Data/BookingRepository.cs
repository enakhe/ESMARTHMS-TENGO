using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public BookingRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddBooking(Booking booking)
        {
            try
            {
                _db.Bookings.Add(booking);
                _db.SaveChanges();
                MessageBox.Show("Successfully added booking information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
    }
}
