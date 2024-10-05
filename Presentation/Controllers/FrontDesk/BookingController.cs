using ESMART_HMS.Application.UseCases.booking;
using ESMART_HMS.Application.UseCases.FrontDesk.booking;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers
{
    public class bookingController
    {
        private readonly CreatebookingUseCase _createBookingUseCase;
        private readonly GetAllbookingsUseCase _getAllBookingsUseCase;
        private readonly IssueCardUseCase _issueCardUseCase;
        private readonly GetbookingByIdUseCase _getBookingByIdUseCase;
        private readonly DeletebookingUseCase _deleteBookingUseCase;
        private readonly GetActivebookingByFilterUseCase _getActiveBookingByFilterUseCase;
        private readonly GetInActivebookingByFilterUseCase _getInActiveBookingByFilterUseCase;
        private readonly GetRoomTypebookingByFilterUseCase _getRoomTypeBookingByFilterUseCase;
        private readonly GetbookingByDateUseCase _getBookingByDateUseCase;
        private readonly GetCheckedOutbookingByDateUseCase _getCheckedOutBookingByDateUseCase;
        private readonly GetAllbookingByDateUseCase _getAllBookingByDateUseCase;

        public bookingController(CreatebookingUseCase createBookingUseCase, GetAllbookingsUseCase getAllBookingsUseCase, IssueCardUseCase issueCardUseCase, GetbookingByIdUseCase getBookingByIdUseCase, DeletebookingUseCase deleteBookingUseCase, GetActivebookingByFilterUseCase getActiveBookingByFilterUseCase, GetInActivebookingByFilterUseCase getInActiveBookingByFilterUseCase, GetRoomTypebookingByFilterUseCase getRoomTypeBookingByFilterUseCase, GetbookingByDateUseCase getBookingByDateUseCase, GetCheckedOutbookingByDateUseCase getCheckedOutBookingByDateUseCase, GetAllbookingByDateUseCase getAllBookingByDateUseCase)
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

        public void Addbooking(Booking booking)
        {
            _createBookingUseCase.Execute(booking);
        }

        public List<BookingViewModel> GetAllbookings()
        {
            return _getAllBookingsUseCase.Execute();
        }

        public List<IssueCardViewModel> IssueCard(string id)
        {
            return _issueCardUseCase.Execute(id);
        }

        public Booking GetbookingById(string id)
        {
            return _getBookingByIdUseCase.Execute(id);
        }

        public void Deletebooking(Booking booking)
        {
            _deleteBookingUseCase.Execute(booking);
        }

        public List<BookingViewModel> GetActivebookingByFilter(string roomTypeId, DateTime from, DateTime to)
        {
            return _getActiveBookingByFilterUseCase.Execute(roomTypeId, from, to);
        }

        public List<BookingViewModel> GetInActivebookingByfilter(string roomTypeId, DateTime from, DateTime to)
        {
            return _getInActiveBookingByFilterUseCase.Execute(roomTypeId, from, to);
        }

        public List<BookingViewModel> GetRoomTypebooking(string roomTypeId, DateTime from, DateTime to)
        {
            return _getRoomTypeBookingByFilterUseCase.Execute(roomTypeId, from, to);
        }

        public List<BookingViewModel> GetbookingByDate(DateTime from, DateTime to)
        {
            return _getBookingByDateUseCase.Execute(from, to);
        }

        public List<BookingViewModel> GetCheckedOutbookingByDate(DateTime from, DateTime to)
        {
            return _getCheckedOutBookingByDateUseCase.Execute(from, to);
        }

        public List<BookingViewModel> GetAllbookingByDate(DateTime from, DateTime to)
        {
            return _getAllBookingByDateUseCase.Execute(from, to);
        }

        public List<BookingViewModel> GetRecycledBooking()
        {
            return _getAllBookingsUseCase.GetRecycledBooking();
        }
    }
}
