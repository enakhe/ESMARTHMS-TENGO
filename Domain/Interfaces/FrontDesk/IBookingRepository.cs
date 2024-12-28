using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        List<BookingViewModel> GetAllBookings();
        List<IssueCardViewModel> IssueCard(string id);
        Booking GetBookingById(string id);
        void DeleteBooking(Booking booking);
        List<BookingViewModel> GetBookingByDate(DateTime fromTime, DateTime endTime);
        List<BookingViewModel> GetCheckedOutBookingByDate(DateTime fromTime, DateTime endTime);
        List<BookingViewModel> GetAllBookingByDate(DateTime fromTime, DateTime endTime);
        List<BookingViewModel> GetActiveBookingByFilter(string roomTypeId, DateTime fromTime, DateTime endTime);
        List<BookingViewModel> GetInActiveBookingByFilter(string roomTypeId, DateTime fromTime, DateTime endTime);
        List<BookingViewModel> GetRoomTypeBookingByFilter(string roomTypeId, DateTime fromTime, DateTime endTime);
        List<BookingViewModel> GetRecycledBookings();
        List<BookingViewModel> SearchBooking(string keyword);
        void UpdateBooking(Booking booking);
        int GetGusteBooking(string id);
    }
}
