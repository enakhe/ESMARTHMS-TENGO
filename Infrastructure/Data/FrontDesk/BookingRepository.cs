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
                                     CheckInDate = booking.CheckInDate.ToString(),
                                     CheckOutDate = booking.CheckOutDate.ToString(),
                                     PaymentMethod = booking.PaymentMethod,
                                     Duration = booking.Duration.ToString() + "Day",
                                     TotalAmount = booking.TotalAmount.ToString(),
                                     CreatedBy = booking.ApplicationUser.FullName,
                                     DateCreated = booking.DateCreated.ToString(),
                                     DateModified = booking.DateModified.ToString(),
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
                                    Floor = booking.Room.Floor.FloorNo,
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

        public List<BookingViewModel> GetActiveBookingByFilter(string roomTypeId, DateTime fromTime, DateTime endTime)
        {
            var allBooking = from booking in _db.Bookings
                .Where(b => b.Room.RoomTypeId == roomTypeId &&
                               (
                                   (b.CheckInDate <= endTime && b.CheckOutDate >= fromTime && b.IsTrashed == false) ||
                                   (b.CheckInDate == null && b.CheckOutDate == null)
                               )).OrderBy(b => b.DateCreated)
                             select new BookingViewModel
                             {
                                 Id = booking.Id,
                                 BookingId = booking.BookingId,
                                 Guest = booking.Guest.Title + " " + booking.Guest.FullName,
                                 GuestPhoneNo = booking.Guest.PhoneNumber,
                                 Room = booking.Room.RoomNo,
                                 CheckInDate = booking.CheckInDate.ToString(),
                                 CheckOutDate = booking.CheckOutDate.ToString(),
                                 PaymentMethod = booking.PaymentMethod,
                                 Duration = booking.Duration.ToString() + "Day",
                                 TotalAmount = booking.TotalAmount.ToString(),
                                 CreatedBy = booking.ApplicationUser.FullName,
                                 DateCreated = booking.DateCreated.ToString(),
                                 DateModified = booking.DateModified.ToString(),
                             };

            return allBooking.ToList(); ;
        }

        public List<BookingViewModel> GetInActiveBookingByFilter(string roomTypeId, DateTime fromTime, DateTime endTime)
        {
            var allBooking = from booking in _db.Bookings
                .Where(b => b.Room.RoomTypeId == roomTypeId &&
                               (
                                   (b.CheckInDate <= endTime && b.CheckOutDate >= fromTime && b.IsTrashed == true) ||
                                   (b.CheckInDate == null && b.CheckOutDate == null)
                               )).OrderBy(b => b.DateCreated)
                             select new BookingViewModel
                             {
                                 Id = booking.Id,
                                 BookingId = booking.BookingId,
                                 Guest = booking.Guest.Title + " " + booking.Guest.FullName,
                                 GuestPhoneNo = booking.Guest.PhoneNumber,
                                 Room = booking.Room.RoomNo,
                                 CheckInDate = booking.CheckInDate.ToString(),
                                 CheckOutDate = booking.CheckOutDate.ToString(),
                                 PaymentMethod = booking.PaymentMethod,
                                 Duration = booking.Duration.ToString() + "Day",
                                 TotalAmount = booking.TotalAmount.ToString(),
                                 CreatedBy = booking.ApplicationUser.FullName,
                                 DateCreated = booking.DateCreated.ToString(),
                                 DateModified = booking.DateModified.ToString(),
                             };

            return allBooking.ToList(); ;
        }

        public List<BookingViewModel> GetBookingByDate(DateTime fromTime, DateTime endTime)
        {
            var allBooking = from booking in _db.Bookings
                .Where(b =>
                               (
                                   (b.CheckInDate <= endTime && b.CheckOutDate >= fromTime && b.IsTrashed == false) ||
                                   (b.CheckInDate == null && b.CheckOutDate == null)
                               )).OrderBy(b => b.DateCreated)
                             select new BookingViewModel
                             {
                                 Id = booking.Id,
                                 BookingId = booking.BookingId,
                                 Guest = booking.Guest.Title + " " + booking.Guest.FullName,
                                 GuestPhoneNo = booking.Guest.PhoneNumber,
                                 Room = booking.Room.RoomNo,
                                 CheckInDate = booking.CheckInDate.ToString(),
                                 CheckOutDate = booking.CheckOutDate.ToString(),
                                 PaymentMethod = booking.PaymentMethod,
                                 Duration = booking.Duration.ToString() + "Day",
                                 TotalAmount = booking.TotalAmount.ToString(),
                                 CreatedBy = booking.ApplicationUser.FullName,
                                 DateCreated = booking.DateCreated.ToString(),
                                 DateModified = booking.DateModified.ToString(),
                             };

            return allBooking.ToList(); ;
        }

        public List<BookingViewModel> GetAllBookingByDate(DateTime fromTime, DateTime endTime)
        {
            var allBooking = from booking in _db.Bookings
                .Where(b =>
                               (
                                   (b.CheckInDate <= endTime && b.CheckOutDate >= fromTime) ||
                                   (b.CheckInDate == null && b.CheckOutDate == null)
                               )).OrderBy(b => b.DateCreated)
                             select new BookingViewModel
                             {
                                 Id = booking.Id,
                                 BookingId = booking.BookingId,
                                 Guest = booking.Guest.Title + " " + booking.Guest.FullName,
                                 GuestPhoneNo = booking.Guest.PhoneNumber,
                                 Room = booking.Room.RoomNo,
                                 CheckInDate = booking.CheckInDate.ToString(),
                                 CheckOutDate = booking.CheckOutDate.ToString(),
                                 PaymentMethod = booking.PaymentMethod,
                                 Duration = booking.Duration.ToString() + "Day",
                                 TotalAmount = booking.TotalAmount.ToString(),
                                 CreatedBy = booking.ApplicationUser.FullName,
                                 DateCreated = booking.DateCreated.ToString(),
                                 DateModified = booking.DateModified.ToString(),
                             };

            return allBooking.ToList(); ;
        }

        public List<BookingViewModel> GetCheckedOutBookingByDate(DateTime fromTime, DateTime endTime)
        {
            var allBooking = from booking in _db.Bookings
                .Where(b =>
                               (
                                   (b.CheckInDate <= endTime && b.CheckOutDate >= fromTime && b.IsTrashed == true) ||
                                   (b.CheckInDate == null && b.CheckOutDate == null)
                               )).OrderBy(b => b.DateCreated)
                             select new BookingViewModel
                             {
                                 Id = booking.Id,
                                 BookingId = booking.BookingId,
                                 Guest = booking.Guest.Title + " " + booking.Guest.FullName,
                                 GuestPhoneNo = booking.Guest.PhoneNumber,
                                 Room = booking.Room.RoomNo,
                                 CheckInDate = booking.CheckInDate.ToString(),
                                 CheckOutDate = booking.CheckOutDate.ToString(),
                                 PaymentMethod = booking.PaymentMethod,
                                 Duration = booking.Duration.ToString() + "Day",
                                 TotalAmount = booking.TotalAmount.ToString(),
                                 CreatedBy = booking.ApplicationUser.FullName,
                                 DateCreated = booking.DateCreated.ToString(),
                                 DateModified = booking.DateModified.ToString(),
                             };

            return allBooking.ToList(); ;
        }

        public List<BookingViewModel> GetRoomTypeBookingByFilter(string roomTypeId, DateTime fromTime, DateTime endTime)
        {
            var allBooking = from booking in _db.Bookings
                .Where(b => b.Room.RoomTypeId == roomTypeId &&
                               (
                                   (b.CheckInDate <= endTime && b.CheckOutDate >= fromTime) ||
                                   (b.CheckInDate == null && b.CheckOutDate == null)
                               )).OrderBy(b => b.DateCreated)
                             select new BookingViewModel
                             {
                                 Id = booking.Id,
                                 BookingId = booking.BookingId,
                                 Guest = booking.Guest.Title + " " + booking.Guest.FullName,
                                 GuestPhoneNo = booking.Guest.PhoneNumber,
                                 Room = booking.Room.RoomNo,
                                 CheckInDate = booking.CheckInDate.ToString(),
                                 CheckOutDate = booking.CheckOutDate.ToString(),
                                 PaymentMethod = booking.PaymentMethod,
                                 Duration = booking.Duration.ToString() + "Day",
                                 TotalAmount = booking.TotalAmount.ToString(),
                                 CreatedBy = booking.ApplicationUser.FullName,
                                 DateCreated = booking.DateCreated.ToString(),
                                 DateModified = booking.DateModified.ToString(),
                             };

            return allBooking.ToList(); ;
        }

        public Booking GetBookingById(string id)
        {
            try
            {
                return _db.Bookings.FirstOrDefault(b => b.Id == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void DeleteBooking(Booking booking)
        {
            try
            {
                if (booking != null)
                {
                    booking.IsTrashed = true;
                    _db.Entry(booking).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("booking not found", "Not Found", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
    }
}
