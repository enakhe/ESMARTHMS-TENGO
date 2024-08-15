using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.Floor
{
    public class CreateFloorUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public CreateFloorUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(Domain.Entities.Floor floor)
        {
            _roomRepository.AddFloor(floor);
        }
    }
}
