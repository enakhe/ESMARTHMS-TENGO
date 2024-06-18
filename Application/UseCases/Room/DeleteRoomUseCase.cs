using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Room
{
    public class DeleteRoomUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public DeleteRoomUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(string Id)
        {
            _roomRepository.DeleteRoom(Id);
        }
    }
}
