using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.Area
{
    public class DeleteRoomTypeUseCase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public DeleteRoomTypeUseCase(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public void Execute(string id)
        {
            _roomTypeRepository.DeleteRoomType(id);
        }
    }
}
