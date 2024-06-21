using ESMART_HMS.Application.UseCases.Reservation;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Presentation.Controllers
{
    public class ReservationController
    {
        private readonly CreateReservationUseCase _addReservationUseCase;
        private readonly GetAllReservationUseCase _allReservationUseCase;

        public ReservationController(CreateReservationUseCase addReservationUseCase, GetAllReservationUseCase allReservationUseCase)
        {
            _addReservationUseCase = addReservationUseCase;
            _allReservationUseCase = allReservationUseCase;
        }

        public void AddReservation(Reservation reservation)
        {
            _addReservationUseCase.Execute(reservation);
        }

        public IList<ReservationViewModel> GetAllReservation()
        {
            return _allReservationUseCase.Execute();
        }
    }
}
