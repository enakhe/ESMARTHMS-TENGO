using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Maintenance.Room
{
    public class GetAllAreaUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public GetAllAreaUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<Domain.Entities.Area> Execute()
        {
            return _roomRepository.GetAllArea();
        }
    }
}
