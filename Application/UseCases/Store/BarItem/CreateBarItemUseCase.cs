using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Store.BarItem
{
    public class CreateBarItemUseCase
    {
        private readonly IBarItemRepository _barRepository;

        public CreateBarItemUseCase(IBarItemRepository barRepository)
        {
            _barRepository = barRepository;
        }

        public void Execute(Domain.Entities.BarItem barItem)
        {
            _barRepository.AddItem(barItem);
        }
    }
}
