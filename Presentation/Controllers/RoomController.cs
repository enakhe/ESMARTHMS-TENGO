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

        public RoomController(GetAllRoomUseCase getAllRoomUseCase)
        {
            _getAllRoomUseCase = getAllRoomUseCase;
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
    }
}
