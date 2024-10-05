using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces.Restaurant
{
    public interface IRestaurantRepository
    {
        void AddItem(MenuItem menuItem);
        List<MenuItemViewModel> GetMenuItems();
        void UpdateMenuItem(MenuItem menuItem);
        MenuItem GetMenuItemById(string id);
        void DeleteMenuItem(string id);
        List<MenuItemViewModel> FilterMenuItem(string keyword);
    }
}
