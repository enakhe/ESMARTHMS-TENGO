using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.Building
{
    public class GetBuildingByIdUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetBuildingByIdUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Domain.Entities.Building Execute(string id)
        {
            return _roomRepository.GetBuildingById(id);
        }
    }
}
