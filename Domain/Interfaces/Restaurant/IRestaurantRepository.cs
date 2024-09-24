using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESMART_HMS.Domain.Entities;

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
