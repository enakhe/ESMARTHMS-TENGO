using ESMART_HMS.Application.UseCases.Room;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers
{
    public class RoomController
    {
        private readonly GetAllRoomUseCase _getAllRoomUseCase;
        private readonly CreateRoomUseCase _createRoomUseCase;
        private readonly GetRoomByIdUseCase _getRoomByIdUseCase;
        private readonly UpdateRoomUseCase _updateRoomUseCase;
        private readonly GetRealRoomUseCase _getRealRoomUseCase;
        private readonly DeleteRoomUseCase _deleteRoomUseCase;
        private readonly GetVacantRoomUseCase _getVacantRoomUseCase;
        private readonly SearchRoomUseCase _searchRoomUseCase;
        private readonly FilterByStatusUseCase _filterByStatusUseCase;
        private readonly FilterByTypeUseCase _filterByTypeUseCase;

        public RoomController(GetAllRoomUseCase getAllRoomUseCase, CreateRoomUseCase createRoomUseCase, GetRoomByIdUseCase getRoomByIdUseCase, UpdateRoomUseCase updateRoomUseCase, GetRealRoomUseCase getRealRoomUseCase, DeleteRoomUseCase deleteRoomUseCase, GetVacantRoomUseCase getVacantRoomUseCase, SearchRoomUseCase searchRoomUseCase, FilterByStatusUseCase filterByStatusUseCase, FilterByTypeUseCase filterByTypeUseCase)
        {
            _getAllRoomUseCase = getAllRoomUseCase;
            _createRoomUseCase = createRoomUseCase;
            _getRoomByIdUseCase = getRoomByIdUseCase;
            _updateRoomUseCase = updateRoomUseCase;
            _getRealRoomUseCase = getRealRoomUseCase;
            _deleteRoomUseCase = deleteRoomUseCase;
            _getVacantRoomUseCase = getVacantRoomUseCase;
            _searchRoomUseCase = searchRoomUseCase;
            _filterByStatusUseCase = filterByStatusUseCase;
            _filterByTypeUseCase = filterByTypeUseCase;
        }

        public List<RoomViewModel> GetAllRooms()
        {
            List<RoomViewModel> allRooms = _getAllRoomUseCase.Execute();
            return allRooms;
        }

        public void CreateRoom(Room room)
        {
            _createRoomUseCase.Execute(room);
        }

        public RoomViewModel GetRoomById(string Id)
        {
            return _getRoomByIdUseCase.Execute(Id);
        }

        public void UpdateRoom(Room room)
        {
            _updateRoomUseCase.Execute(room);
        }

        public Room GetRealRoom(string Id)
        {
            return _getRealRoomUseCase.Execute(Id);
        }

        public void DeleteRoom(string Id)
        {
            _deleteRoomUseCase.Execute(Id);
        }

        public List<RoomViewModel> GetAvailbleRoom()
        {
            return _getVacantRoomUseCase.Execute();
        }

        public List<RoomViewModel> SearchRoom(string keyword)
        {
            return _searchRoomUseCase.Execute(keyword);
        }

        public List<RoomViewModel> FilterByStatus(string keyword)
        {
            return _filterByStatusUseCase.Execute(keyword);
        }

        public List<RoomViewModel> FilterByType(string keyword)
        {
            return _filterByTypeUseCase.Execute(keyword);
        }
    }
}
