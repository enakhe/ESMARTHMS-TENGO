using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Reservation
{
    public class AddReservationUseCase
    {
        private readonly IReservationRepository _reservationRepository;

        public AddReservationUseCase(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public void Execute(ESMART_HMS.Domain.Entities.Reservation reservation)
        {
            _reservationRepository.AddReservation(reservation);
        }
    }
}
