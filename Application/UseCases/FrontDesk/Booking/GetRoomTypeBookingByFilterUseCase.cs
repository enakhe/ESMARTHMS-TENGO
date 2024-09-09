using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.FrontDesk.Booking
{
    public class GetRoomTypeBookingByFilterUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public GetRoomTypeBookingByFilterUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<BookingViewModel> Execute(string roomTypeId, DateTime from, DateTime to)
        {
            return _bookingRepository.GetRoomTypeBookingByFilter(roomTypeId, from, to);
        }
    }
}
