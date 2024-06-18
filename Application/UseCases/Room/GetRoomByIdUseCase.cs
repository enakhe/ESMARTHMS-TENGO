using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;

namespace ESMART_HMS.Application.UseCases.Room
{
    public class GetRoomByIdUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomByIdUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public RoomViewModel Execute(string Id)
        {
            return _roomRepository.GetRoomById(Id);
        }
    }
}
