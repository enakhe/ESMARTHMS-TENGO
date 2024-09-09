using ESMART_HMS.Application.UseCases.Booking;
using ESMART_HMS.Application.UseCases.FrontDesk.Booking;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers
{
    public class BookingController
    {
        private readonly CreateBookingUseCase _createBookingUseCase;
        private readonly GetAllBookingsUseCase _getAllBookingsUseCase;
        private readonly IssueCardUseCase _issueCardUseCase;
        private readonly GetBookingByIdUseCase _getBookingByIdUseCase;
        private readonly DeleteBookingUseCase _deleteBookingUseCase;
        private readonly GetActiveBookingByFilterUseCase _getActiveBookingByFilterUseCase;
        private readonly GetInActiveBookingByFilterUseCase _getInActiveBookingByFilterUseCase;
        private readonly GetRoomTypeBookingByFilterUseCase _getRoomTypeBookingByFilterUseCase;
        private readonly GetBookingByDateUseCase _getBookingByDateUseCase;
        private readonly GetCheckedOutBookingByDateUseCase _getCheckedOutBookingByDateUseCase;
        private readonly GetAllBookingByDateUseCase _getAllBookingByDateUseCase;

        public BookingController(CreateBookingUseCase createBookingUseCase, GetAllBookingsUseCase getAllBookingsUseCase, IssueCardUseCase issueCardUseCase, GetBookingByIdUseCase getBookingByIdUseCase, DeleteBookingUseCase deleteBookingUseCase, GetActiveBookingByFilterUseCase getActiveBookingByFilterUseCase, GetInActiveBookingByFilterUseCase getInActiveBookingByFilterUseCase, GetRoomTypeBookingByFilterUseCase getRoomTypeBookingByFilterUseCase, GetBookingByDateUseCase getBookingByDateUseCase, GetCheckedOutBookingByDateUseCase getCheckedOutBookingByDateUseCase, GetAllBookingByDateUseCase getAllBookingByDateUseCase)
        {
            _createBookingUseCase = createBookingUseCase;
            _getAllBookingsUseCase = getAllBookingsUseCase;
            _issueCardUseCase = issueCardUseCase;
            _getBookingByIdUseCase = getBookingByIdUseCase;
            _deleteBookingUseCase = deleteBookingUseCase;
            _getActiveBookingByFilterUseCase = getActiveBookingByFilterUseCase;
            _getInActiveBookingByFilterUseCase = getInActiveBookingByFilterUseCase;
            _getRoomTypeBookingByFilterUseCase = getRoomTypeBookingByFilterUseCase;
            _getBookingByDateUseCase = getBookingByDateUseCase;
            _getCheckedOutBookingByDateUseCase = getCheckedOutBookingByDateUseCase;
            _getAllBookingByDateUseCase = getAllBookingByDateUseCase;
        }

        public void AddBooking(Booking booking)
        {
            _createBookingUseCase.Execute(booking);
        }

        public List<BookingViewModel> GetAllBookings()
        {
            return _getAllBookingsUseCase.Execute();
        }

        public List<IssueCardViewModel> IssueCard(string id)
        {
            return _issueCardUseCase.Execute(id);
        }

        public Booking GetBookingById(string id)
        {
            return _getBookingByIdUseCase.Execute(id);
        }

        public void DeleteBooking(Booking booking)
        {
            _deleteBookingUseCase.Execute(booking);
        }

        public List<BookingViewModel> GetActiveBookingByFilter(string roomTypeId, DateTime from, DateTime to)
        {
            return _getActiveBookingByFilterUseCase.Execute(roomTypeId, from, to);
        }

        public List<BookingViewModel> GetInActiveBookingByfilter(string roomTypeId, DateTime from, DateTime to)
        {
            return _getInActiveBookingByFilterUseCase.Execute(roomTypeId, from, to);
        }

        public List<BookingViewModel> GetRoomTypeBooking(string roomTypeId, DateTime from, DateTime to)
        {
            return _getRoomTypeBookingByFilterUseCase.Execute(roomTypeId, from, to);
        }

        public List<BookingViewModel> GetBookingByDate(DateTime from, DateTime to)
        {
            return _getBookingByDateUseCase.Execute(from, to);
        }

        public List<BookingViewModel> GetCheckedOutBookingByDate(DateTime from, DateTime to)
        {
            return _getCheckedOutBookingByDateUseCase.Execute(from, to);
        }

        public List<BookingViewModel> GetAllBookingByDate(DateTime from, DateTime to)
        {
            return _getAllBookingByDateUseCase.Execute(from, to);
        }
    }
}
