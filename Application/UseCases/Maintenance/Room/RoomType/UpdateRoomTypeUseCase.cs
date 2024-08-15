using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.RoomType
{
    public class UpdateRoomTypeUseCase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public UpdateRoomTypeUseCase(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }


        public void Execute(Domain.Entities.RoomType roomType)
        {
            _roomTypeRepository.UpdateRoomType(roomType);
        }
    }
}
