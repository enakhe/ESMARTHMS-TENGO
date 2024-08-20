using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room.Building
{
    public class DeleteBuildingUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public DeleteBuildingUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void Execute(string id)
        {
            _roomRepository.DeleteBuilding(id);
        }
    }
}
