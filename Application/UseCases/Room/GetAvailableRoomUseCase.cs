using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Room
{
    public class GetAvailableRoomUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetAvailableRoomUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<RoomViewModel> Execute()
        {
            return _roomRepository.GetAvailableRoom();
        }
    }
}
