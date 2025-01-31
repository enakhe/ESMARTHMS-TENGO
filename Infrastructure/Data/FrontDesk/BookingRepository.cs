﻿using DocumentFormat.OpenXml.Drawing;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Enum;
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
                List<Booking> bookings = _db.Bookings.Where(b => b.IsTrashed == false).OrderBy(b => b.DateCreated).ToList();
                foreach (var booking in bookings)
                {
                    if (booking.CheckOutDate < DateTime.Now)
                    {
                        DeleteBooking(booking);
                    }
                }
                var allbooking = from booking in bookings
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
                return allbooking.ToList();
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
            var allbooking = from booking in _db.Bookings
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

            return allbooking.ToList(); ;
        }

        public List<BookingViewModel> GetInActiveBookingByFilter(string roomTypeId, DateTime fromTime, DateTime endTime)
        {
            var allbooking = from booking in _db.Bookings
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

            return allbooking.ToList(); ;
        }

        public List<BookingViewModel> GetBookingByDate(DateTime fromTime, DateTime endTime)
        {
            var allbooking = from booking in _db.Bookings
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

            return allbooking.ToList(); ;
        }

        public List<BookingViewModel> GetAllBookingByDate(DateTime fromTime, DateTime endTime)
        {
            var allbooking = from booking in _db.Bookings
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

            return allbooking.ToList(); ;
        }

        public List<BookingViewModel> GetCheckedOutBookingByDate(DateTime fromTime, DateTime endTime)
        {
            var allbooking = from booking in _db.Bookings
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

            return allbooking.ToList(); ;
        }

        public List<BookingViewModel> GetRoomTypeBookingByFilter(string roomTypeId, DateTime fromTime, DateTime endTime)
        {
            var allbooking = from booking in _db.Bookings
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

            return allbooking.ToList(); ;
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
                    var room = _db.Rooms.FirstOrDefault(r => r.Id == booking.Room.Id);
                    room.Status = RoomStatusEnum.Vacant.ToString();
                    booking.IsTrashed = true;
                    _db.Entry(booking).State = System.Data.Entity.EntityState.Modified;
                    _db.Entry(room).State = System.Data.Entity.EntityState.Modified;
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

        public List<BookingViewModel> GetRecycledBookings()
        {
            try
            {
                List<Booking> bookings = _db.Bookings.Where(b => b.IsTrashed == true).OrderBy(b => b.DateCreated).ToList();
                foreach (var booking in bookings)
                {
                    if (booking.CheckOutDate < DateTime.Now)
                    {
                        DeleteBooking(booking);
                    }
                }
                var allbooking = from booking in bookings
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
                return allbooking.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public List<BookingViewModel> SearchBooking(string keyword)
        {
            try
            {
                var allbooking = from booking in _db.Bookings
                .Where(b => b.IsTrashed != false && b.Room.RoomNo.Contains(keyword) || b.Guest.FullName.Contains(keyword) || b.Room.RoomType.Title == keyword)
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

                return allbooking.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured when searching booking", ex);
            }
        }

        public void UpdateBooking(Booking booking)
        {
            try
            {
                _db.Entry(booking).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                MessageBox.Show("Successfully edited booking information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public int GetGusteBooking(string id)
        {
            try
            {
                return _db.Bookings.Where(b => b.GuestId == id).ToList().Count();
            }
            catch(Exception ex)
            {
                throw new Exception("Error retriving total number of Guest Booking", ex);
            }
        }
    }
}
