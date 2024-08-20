using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.Building
{
    public class GetAllBuildingUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetAllBuildingUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<Domain.Entities.Building> Execute()
        {
            return _roomRepository.GetAllBuildings();
        }
    }
}
