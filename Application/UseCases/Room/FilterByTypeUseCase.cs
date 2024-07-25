using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Room
{
    public class FilterByTypeUseCase
    {
        private readonly IRoomRepository _roomRepository;

        public FilterByTypeUseCase(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<RoomViewModel> Execute(string keyword)
        {
            return _roomRepository.FilterByType(keyword);
        }
    }
}
