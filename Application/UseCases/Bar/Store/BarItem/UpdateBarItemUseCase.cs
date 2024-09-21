using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Bar.Store.BarItem
{
    public class UpdateBarItemUseCase
    {
        private readonly IBarItemRepository _barItemRepository;

        public UpdateBarItemUseCase(IBarItemRepository barItemRepository)
        {
            _barItemRepository = barItemRepository;
        }

        public void Execute(Domain.Entities.BarItem barItem)
        {
            _barItemRepository.UpdateBarItem(barItem);
        }
    }
}
