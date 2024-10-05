using ESMART_HMS.Application.UseCases.Bar.Store.BarItem;
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
        private readonly UpdateBarItemUseCase _updateBarItemUseCase;
        private readonly GetBarItemByIdUseCase _getByIdUseCase;
        private readonly DeleteBarItemUseCase _deleteBarItemUseCase;
        private readonly FilterBarItemUseCase _filterBarItemUseCase;

        public BarItemController(CreateBarItemUseCase createBarItemUseCase, GetAllBarItemUseCase getAllBarItemUseCase, UpdateBarItemUseCase updateBarItemUseCase, GetBarItemByIdUseCase getByIdUseCase, DeleteBarItemUseCase deleteBarItemUseCase, FilterBarItemUseCase filterBarItemUseCase)
        {
            _createBarItemUseCase = createBarItemUseCase;
            _getAllBarItemUseCase = getAllBarItemUseCase;
            _updateBarItemUseCase = updateBarItemUseCase;
            _getByIdUseCase = getByIdUseCase;
            _deleteBarItemUseCase = deleteBarItemUseCase;
            _filterBarItemUseCase = filterBarItemUseCase;
        }

        public void AddItem(Domain.Entities.MenuItem menuItem)
        {
            _createBarItemUseCase.Execute(menuItem);
        }

        public List<BarItemViewModel> GetAllBarItem()
        {
            return _getAllBarItemUseCase.Execute();
        }

        public void UpdateBarItem(Domain.Entities.MenuItem menuItem) 
        {
            _updateBarItemUseCase.Execute(menuItem);
        }

        public Domain.Entities.MenuItem GetBarItemById(string id)
        {
            return _getByIdUseCase.Execute(id);
        }

        public void DeleteBarItem(string id)
        {
            _deleteBarItemUseCase.Execute(id);
        }

        public List<BarItemViewModel> FilterBarItem(string keyword)
        {
            return _filterBarItemUseCase.Execute(keyword);
        }
    }
}
