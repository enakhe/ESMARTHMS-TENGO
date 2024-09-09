using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.FrontDesk.Booking
{
    public class GetBookingByIdUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingByIdUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Domain.Entities.Booking Execute(string id)
        {
            return _bookingRepository.GetBookingById(id);
        }
    }
}
