using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.FrontDesk.Booking
{
    public class GetAllBookingByDateUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public GetAllBookingByDateUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<BookingViewModel> Execute(DateTime from, DateTime to)
        {
            return _bookingRepository.GetAllBookingByDate(from, to);
        }
    }
}
