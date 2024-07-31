using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.RoomTypes
{
    public class GetAllRoomTypeUseCase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public GetAllRoomTypeUseCase(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public List<RoomType> Execute()
        {
            return _roomTypeRepository.GetAllRoomTypes();
        }
    }
}
