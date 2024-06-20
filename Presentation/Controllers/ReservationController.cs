using ESMART_HMS.Application.UseCases.Reservation;
using ESMART_HMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Presentation.Controllers
{
    public class ReservationController
    {
        private readonly AddReservationUseCase _addReservationUseCase;

        public ReservationController(AddReservationUseCase addReservationUseCase)
        {
            _addReservationUseCase = addReservationUseCase;
        }

        public void AddReservation(Reservation reservation)
        {
            _addReservationUseCase.Execute(reservation);
        }
    }
}
