using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.RoomTypes
{
    public class GetRoomTypeByIdUseCase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public GetRoomTypeByIdUseCase(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public RoomType Execute(string Id)
        {
            return _roomTypeRepository.GetRoomTypeById(Id);
        }
    }
}
