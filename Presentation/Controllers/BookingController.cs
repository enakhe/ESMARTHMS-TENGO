using ESMART_HMS.Application.UseCases.Booking;
using ESMART_HMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Presentation.Controllers
{
    public class BookingController
    {
        private readonly CreateBookingUseCase _createBookingUseCase;

        public BookingController(CreateBookingUseCase createBookingUseCase)
        {
            _createBookingUseCase = createBookingUseCase;
        }

        public void AddBooking(Booking booking)
        {
            _createBookingUseCase.Execute(booking);
        }
    }
}
