using ESMART_HMS.Domain.Interfaces;

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
