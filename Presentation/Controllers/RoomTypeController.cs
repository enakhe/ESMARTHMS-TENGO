using ESMART_HMS.Application.UseCases.RoomTypes;
using ESMART_HMS.Domain.Entities;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers
{
    public class RoomTypeController
    {
        private readonly CreateRoomTypeUseCase _createRoomTypeUseCase;
        private readonly GetAllRoomTypeUseCase _getAllRoomTypeUseCase;

        public RoomTypeController(CreateRoomTypeUseCase createRoomTypeUseCase, GetAllRoomTypeUseCase getAllRoomTypeUseCase)
        {
            _createRoomTypeUseCase = createRoomTypeUseCase;
            _getAllRoomTypeUseCase = getAllRoomTypeUseCase;
        }

        public void AddRoomType(RoomType roomType)
        {
            _createRoomTypeUseCase.Execute(roomType);
        }

        public List<RoomType> GetAllRoomType()
        {
            return _getAllRoomTypeUseCase.Execute();
        }
    }
}
