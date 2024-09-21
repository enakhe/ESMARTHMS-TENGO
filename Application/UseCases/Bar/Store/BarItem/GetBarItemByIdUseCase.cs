using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Bar.Store.BarItem
{
    public class GetBarItemByIdUseCase
    {
        private readonly IBarItemRepository _barItemRepository;

        public GetBarItemByIdUseCase(IBarItemRepository barItemRepository)
        {
            _barItemRepository = barItemRepository;
        }

        public Domain.Entities.BarItem Execute(string id)
        {
            return _barItemRepository.GetBarItemById(id);
        }
    }
}
