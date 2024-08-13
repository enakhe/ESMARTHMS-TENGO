using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.FrontDesk.Booking
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
