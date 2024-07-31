using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

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
