using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.FrontDesk.Booking
{
    public class DeleteBookingUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public DeleteBookingUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void Execute(Domain.Entities.Booking booking)
        {
            _bookingRepository.DeleteBooking(booking);
        }
    }
}
