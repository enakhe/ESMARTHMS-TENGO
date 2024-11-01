using ESMART_HMS.Application.UseCases.Reservation;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers
{
    public class ReservationController
    {
        private readonly CreateReservationUseCase _addReservationUseCase;
        private readonly GetAllReservationUseCase _allReservationUseCase;
        private readonly GetReservationByIdUseCase _getReservationByIdUseCase;
        private readonly UpdateReservationUseCase _updateReservationUseCase;

        public ReservationController(CreateReservationUseCase addReservationUseCase, GetAllReservationUseCase allReservationUseCase, GetReservationByIdUseCase getReservationByIdUseCase, UpdateReservationUseCase updateReservationUseCase)
        {
            _addReservationUseCase = addReservationUseCase;
            _allReservationUseCase = allReservationUseCase;
            _getReservationByIdUseCase = getReservationByIdUseCase;
            _updateReservationUseCase = updateReservationUseCase;
        }

        public void AddReservation(Reservation reservation)
        {
            _addReservationUseCase.Execute(reservation);
        }

        public IList<ReservationViewModel> GetAllReservation()
        {
            return _allReservationUseCase.Execute();
        }

        public Reservation GetReservationById(string Id)
        {
            return _getReservationByIdUseCase.Execute(Id);
        }

        public void UpdateReservation(Reservation reservation)
        {
            _updateReservationUseCase.Execute(reservation);
        }
    }
}
