using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Room
{
    public class UpdateRoomUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public UpdateRoomUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(ESMART_HMS.Domain.Entities.Room room)
        {
            _roomRepository.UpdateRoom(room);
        }
    }
}
