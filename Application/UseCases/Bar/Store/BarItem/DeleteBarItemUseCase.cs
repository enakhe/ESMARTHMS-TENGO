using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Bar.Store.BarItem
{
    public class DeleteBarItemUseCase
    {
        private readonly IBarItemRepository _barItemRepository;

        public DeleteBarItemUseCase(IBarItemRepository barItemRepository)
        {
            _barItemRepository = barItemRepository;
        }

        public void Execute(string id)
        {
            _barItemRepository.DeleteBarItem(id);
        }
    }
}
