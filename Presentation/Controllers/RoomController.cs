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
        private readonly GetAvailableRoomUseCase _getAvailableRoomUseCase;

        public RoomController(GetAllRoomUseCase getAllRoomUseCase, CreateRoomUseCase createRoomUseCase, GetRoomByIdUseCase getRoomByIdUseCase, UpdateRoomUseCase updateRoomUseCase, GetRealRoomUseCase getRealRoomUseCase, DeleteRoomUseCase deleteRoomUseCase, GetAvailableRoomUseCase getAvailableRoomUseCase)
        {
            _getAllRoomUseCase = getAllRoomUseCase;
            _createRoomUseCase = createRoomUseCase;
            _getRoomByIdUseCase = getRoomByIdUseCase;
            _updateRoomUseCase = updateRoomUseCase;
            _getRealRoomUseCase = getRealRoomUseCase;
            _deleteRoomUseCase = deleteRoomUseCase;
            _getAvailableRoomUseCase = getAvailableRoomUseCase;
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
            return _getAvailableRoomUseCase.Execute();
        }
    }
}
