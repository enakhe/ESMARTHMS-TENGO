using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Application.UseCases.Store.BarItem
{
    public class GetAllBarItemUseCase
    {
        private readonly IBarItemRepository _barRepository;

        public GetAllBarItemUseCase(IBarItemRepository barRepository)
        {
            _barRepository = barRepository;
        }


        public List<BarItemViewModel> Execute()
        {
            return _barRepository.GetBarItems();
        }
    }
}
