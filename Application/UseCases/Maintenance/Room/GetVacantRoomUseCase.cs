using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Room
{
    public class GetVacantRoomUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetVacantRoomUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<RoomViewModel> Execute()
        {
            return _roomRepository.GetVacantRoom();
        }
    }
}
