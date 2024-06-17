using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Room
{
    public class GetRealRoomUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetRealRoomUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public ESMART_HMS.Domain.Entities.Room Execute(string Id)
        {
            return _roomRepository.GetRealRoom(Id);
        }
    }
}
