using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IBarItemRepository
    {
        void AddItem(MenuItem barItem);
        List<BarItemViewModel> GetBarItems();
        void UpdateBarItem(MenuItem barItem);
        MenuItem GetBarItemById(string id);
        void DeleteBarItem(string id);
        List<BarItemViewModel> FilterBarItem(string keyword);
    }
}
