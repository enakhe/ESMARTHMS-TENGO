using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.FrontDesk.booking
{
    public class GetCheckedOutbookingByDateUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public GetCheckedOutbookingByDateUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<BookingViewModel> Execute(DateTime from, DateTime to)
        {
            return _bookingRepository.GetCheckedOutBookingByDate(from, to);
        }
    }
}
