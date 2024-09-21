using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.FrontDesk.booking
{
    public class IssueCardUseCase
    {
        private readonly IBookingRepository _bookingRepository;

        public IssueCardUseCase(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<IssueCardViewModel> Execute(string id)
        {
            return _bookingRepository.IssueCard(id);
        }
    }
}
