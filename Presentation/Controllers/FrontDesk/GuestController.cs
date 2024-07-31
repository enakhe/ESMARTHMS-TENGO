using ESMART_HMS.Application.UseCases.Guest;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ESMART_HMS.Presentation.Controllers
{
    public class GuestController
    {
        private readonly GetAllGuestUseCase _getAllGuestsUseCase;
        private readonly CreateGuestUseCase _createGuestUseCase;
        private readonly UpdateGuestUseCase _updateGuestUseCase;
        private readonly GetGuestByIdUseCase _getGuestByIdUseCase;
        private readonly DeleteGuestUseCase _deleteGuestUseCase;
        private readonly SearchGuestUseCase _searchGuestUseCase;
        private readonly GetDeletedGuestUseCase _getDeletedGuestUseCase;

        public ObservableCollection<Guest> Guests { get; set; }

        public GuestController(GetAllGuestUseCase getAllGuestsUseCase, CreateGuestUseCase createGuestUseCase, UpdateGuestUseCase updateGuestUseCase, GetGuestByIdUseCase getGuestByIdUseCase, DeleteGuestUseCase deleteGuestUseCase, SearchGuestUseCase searchGuestUseCase, GetDeletedGuestUseCase getDeletedGuestUseCase)
        {
            _getAllGuestsUseCase = getAllGuestsUseCase;
            _createGuestUseCase = createGuestUseCase;
            _updateGuestUseCase = updateGuestUseCase;
            _getGuestByIdUseCase = getGuestByIdUseCase;
            _deleteGuestUseCase = deleteGuestUseCase;
            _searchGuestUseCase = searchGuestUseCase;
            _getDeletedGuestUseCase = getDeletedGuestUseCase;

            LoadGuests();
        }

        public List<GuestViewModel> LoadGuests()
        {
            return _getAllGuestsUseCase.Execute();
        }

        public void AddGuest(Guest customer)
        {
            _createGuestUseCase.Execute(customer);
        }

        public void UpdateGuest(Guest customer)
        {
            _updateGuestUseCase.Execute(customer);
        }

        public Guest GetGuestById(string Id)
        {
            return _getGuestByIdUseCase.Execute(Id);
        }

        public void DeleteGuest(string Id)
        {
            _deleteGuestUseCase.Execute(Id);
        }

        public List<GuestViewModel> SearchGuest(string keyword)
        {
            return _searchGuestUseCase.Execute(keyword);
        }
        public List<ESMART_HMS.Domain.Entities.Guest> GetDeletedGuest()
        {
            return _getDeletedGuestUseCase.Execute();
        }
    }
}
