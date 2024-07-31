using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Room
{
    public class GetAllRoomUseCase
    {
        private readonly IRoomRepository _roomRepository;
        public GetAllRoomUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<RoomViewModel> Execute()
        {
            List<RoomViewModel> allRooms = _roomRepository.GetAllRooms();
            return allRooms;
        }
    }
}
