using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.Area
{
    public class GetAreaByIdUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetAreaByIdUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Domain.Entities.Area Execute(string id)
        {
            return _roomRepository.GetAresById(id);
        }
    }
}
