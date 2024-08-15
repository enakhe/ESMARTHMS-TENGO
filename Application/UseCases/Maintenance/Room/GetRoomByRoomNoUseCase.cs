using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room
{
    public class GetRoomByRoomNoUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomByRoomNoUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Domain.Entities.Room Execute(string roomNo)
        {
            return _roomRepository.FindByRoomNo(roomNo);
        }
    }
}
