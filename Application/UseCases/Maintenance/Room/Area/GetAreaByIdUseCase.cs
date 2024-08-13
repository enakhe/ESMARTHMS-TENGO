using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
