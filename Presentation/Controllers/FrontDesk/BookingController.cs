using ESMART_HMS.Application.UseCases.Booking;
using ESMART_HMS.Application.UseCases.FrontDesk.Booking;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers
{
    public class BookingController
    {
        private readonly CreateBookingUseCase _createBookingUseCase;
        private readonly GetAllBookingsUseCase _getAllBookingsUseCase;
        private readonly IssueCardUseCase _issueCardUseCase;
        private readonly GetBookingByIdUseCase _getBookingByIdUseCase;

        public BookingController(CreateBookingUseCase createBookingUseCase, GetAllBookingsUseCase getAllBookingsUseCase, IssueCardUseCase issueCardUseCase, GetBookingByIdUseCase getBookingByIdUseCase)
        {
            _createBookingUseCase = createBookingUseCase;
            _getAllBookingsUseCase = getAllBookingsUseCase;
            _issueCardUseCase = issueCardUseCase;
            _getBookingByIdUseCase = getBookingByIdUseCase;
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


    }
}
