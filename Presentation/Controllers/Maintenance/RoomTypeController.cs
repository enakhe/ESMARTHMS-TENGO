using ESMART_HMS.Application.UseCases.Maintenance.Room.Area;
using ESMART_HMS.Application.UseCases.Maintenance.Room.RoomType;
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
        private readonly UpdateRoomTypeUseCase _updateRoomTypeUseCase;
        private readonly DeleteRoomTypeUseCase _deleteRoomTypeUseCase;

        public RoomTypeController(CreateRoomTypeUseCase createRoomTypeUseCase, GetAllRoomTypeUseCase getAllRoomTypeUseCase, GetRoomTypeByIdUseCase getRoomTypeByIdUseCase, UpdateRoomTypeUseCase updateRoomTypeUseCase, DeleteRoomTypeUseCase deleteRoomTypeUseCase)
        {
            _createRoomTypeUseCase = createRoomTypeUseCase;
            _getAllRoomTypeUseCase = getAllRoomTypeUseCase;
            _getRoomTypeByIdUseCase = getRoomTypeByIdUseCase;
            _updateRoomTypeUseCase = updateRoomTypeUseCase;
            _deleteRoomTypeUseCase = deleteRoomTypeUseCase;
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

        public void UpdateRoomType(RoomType roomType)
        {
            _updateRoomTypeUseCase.Execute(roomType);
        }

        public void DeleteRoomType(string id)
        {
            _deleteRoomTypeUseCase.Execute(id);
        }
    }
}
