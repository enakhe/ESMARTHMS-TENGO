using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<BookingViewModel> GetAllBookings()
        {
            try
            {
                var allBooking = from booking in _db.Bookings.Where(b => b.IsTrashed == false).OrderBy(b => b.DateCreated)
                                 select new BookingViewModel
                                 {
                                     Id = booking.Id,
                                     BookingId = booking.BookingId,
                                     Guest = booking.Guest.Title + " " + booking.Guest.FullName,
                                     GuestPhoneNo = booking.Guest.PhoneNumber,
                                     Room = booking.Room.RoomNo,
                                     CheckInDate = booking.CheckInDate,
                                     CheckOutDate = booking.CheckOutDate,
                                     PaymentMethod = booking.PaymentMethod,
                                     Duration = booking.Duration.ToString() + "Day",
                                     TotalAmount = booking.TotalAmount.ToString(),
                                     CreatedBy = booking.ApplicationUser.FullName,
                                     DateCreated = booking.DateCreated,
                                     DateModified = booking.DateModified,
                                 };
                return allBooking.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public List<IssueCardViewModel> IssueCard(string id)
        {
            try
            {
                var issueCard = from booking in _db.Bookings.Where(b => b.Id == id)
                                select new IssueCardViewModel
                                {
                                    Room = booking.Room.RoomNo,
                                    RoomType = booking.Room.RoomType.Title,
                                    Amount = booking.TotalAmount.ToString(),
                                };
                return issueCard.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
