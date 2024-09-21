using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.FrontDesk.booking
{
    public class GetbookingByIdUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public GetbookingByIdUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Domain.Entities.Booking Execute(string id)
        {
            return _bookingRepository.GetBookingById(id);
        }
    }
}
