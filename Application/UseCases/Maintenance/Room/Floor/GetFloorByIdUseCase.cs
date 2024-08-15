using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Repositories;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.Floor
{
    public class GetFloorByIdUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetFloorByIdUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Domain.Entities.Floor Execute(string id)
        {
            return _roomRepository.GetFloorById(id);
        }
    }
}
