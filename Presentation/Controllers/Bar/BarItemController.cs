using ESMART_HMS.Application.UseCases.Store.BarItem;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers
{
    public class BarItemController
    {
        private readonly CreateBarItemUseCase _createBarItemUseCase;
        private readonly GetAllBarItemUseCase _getAllBarItemUseCase;

        public BarItemController(CreateBarItemUseCase createBarItemUseCase, GetAllBarItemUseCase getAllBarItemUseCase)
        {
            _createBarItemUseCase = createBarItemUseCase;
            _getAllBarItemUseCase = getAllBarItemUseCase;
        }

        public void AddItem(BarItem barItem)
        {
            _createBarItemUseCase.Execute(barItem);
        }

        public List<BarItemViewModel> GetAllBarItem()
        {
            return _getAllBarItemUseCase.Execute();
        }
    }
}
