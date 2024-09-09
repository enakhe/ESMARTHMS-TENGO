using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.FrontDesk.Booking
{
    public class GetBookingByDateUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingByDateUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<BookingViewModel> Execute(DateTime from, DateTime to)
        {
            return _bookingRepository.GetBookingByDate(from, to);
        }
    }
}
