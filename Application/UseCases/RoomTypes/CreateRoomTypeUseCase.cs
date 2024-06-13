using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.RoomTypes
{
    public class CreateRoomTypeUseCase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public CreateRoomTypeUseCase(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public void Execute(ESMART_HMS.Domain.Entities.RoomType roomType)
        {
            _roomTypeRepository.AddRoomType(roomType);
        }
    }
}
