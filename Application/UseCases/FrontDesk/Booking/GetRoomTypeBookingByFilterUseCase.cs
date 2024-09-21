using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.FrontDesk.booking
{
    public class GetRoomTypebookingByFilterUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public GetRoomTypebookingByFilterUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<BookingViewModel> Execute(string roomTypeId, DateTime from, DateTime to)
        {
            return _bookingRepository.GetRoomTypeBookingByFilter(roomTypeId, from, to);
        }
    }
}
