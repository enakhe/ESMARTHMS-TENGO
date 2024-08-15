using ESMART_HMS.Domain.Interfaces;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.Floor
{
    public class GetAllFloorUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetAllFloorUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<Domain.Entities.Floor> Execute()
        {
            return _roomRepository.GetAllFloors();
        }
    }
}
