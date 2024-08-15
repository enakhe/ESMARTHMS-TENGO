using ESMART_HMS.Domain.Interfaces;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.Area
{
    public class UpdateAreaUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public UpdateAreaUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }


        public void Execute(Domain.Entities.Area area)
        {
            _roomRepository.UpdateArea(area);
        }
    }
}
