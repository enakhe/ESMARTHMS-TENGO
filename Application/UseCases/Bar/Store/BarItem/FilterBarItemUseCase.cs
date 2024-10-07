using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Bar.Store.BarItem
{
    public class FilterBarItemUseCase
    {
        private readonly IBarItemRepository _barItemRepository;

        public FilterBarItemUseCase(IBarItemRepository barItemRepository)
        {
            _barItemRepository = barItemRepository;
        }

        public List<BarItemViewModel> Execute(string keyword)
        {
            return _barItemRepository.FilterBarItem(keyword);
        }
    }
}
