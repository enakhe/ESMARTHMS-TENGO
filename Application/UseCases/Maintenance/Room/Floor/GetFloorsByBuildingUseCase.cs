using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.Floor
{
    public class GetFloorsByBuildingUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetFloorsByBuildingUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<Domain.Entities.Floor> Execute(string id)
        {
            return _roomRepository.GetFloorsByBuilding(id);
        }

    }
}
