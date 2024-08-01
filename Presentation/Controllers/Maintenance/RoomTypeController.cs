using ESMART_HMS.Application.UseCases.RoomTypes;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers
{
    public class RoomTypeController
    {
        private readonly CreateRoomTypeUseCase _createRoomTypeUseCase;
        private readonly GetAllRoomTypeUseCase _getAllRoomTypeUseCase;
        private readonly GetRoomTypeByIdUseCase _getRoomTypeByIdUseCase;

        public RoomTypeController(CreateRoomTypeUseCase createRoomTypeUseCase, GetAllRoomTypeUseCase getAllRoomTypeUseCase, GetRoomTypeByIdUseCase getRoomTypeByIdUseCase)
        {
            _createRoomTypeUseCase = createRoomTypeUseCase;
            _getAllRoomTypeUseCase = getAllRoomTypeUseCase;
            _getRoomTypeByIdUseCase = getRoomTypeByIdUseCase;
        }

        public void AddRoomType(RoomType roomType)
        {
            _createRoomTypeUseCase.Execute(roomType);
        }

        public List<RoomTypeViewModel> GetAllRoomType()
        {
            return _getAllRoomTypeUseCase.Execute();
        }

        public RoomType GetRoomTypeById(string id)
        {
            return _getRoomTypeByIdUseCase.Execute(id);
        }
    }
}
