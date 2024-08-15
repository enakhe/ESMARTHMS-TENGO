using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.Floor
{
    public class DeleteFloorUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public DeleteFloorUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(string id)
        {
            _roomRepository.DeleteFloor(id);
        }
    }
}
