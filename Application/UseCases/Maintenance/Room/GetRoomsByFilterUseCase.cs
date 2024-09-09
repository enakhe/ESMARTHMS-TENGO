using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room
{
    public class GetRoomsByFilterUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomsByFilterUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<RoomViewModel> Execute(string roomTypeId, string status)
        {
            return _roomRepository.GetRoomsByFilter(roomTypeId, status);
        }
    }
}
