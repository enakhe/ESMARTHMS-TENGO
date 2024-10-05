using ESMART_HMS.Application.UseCases.Restaurant;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers.Restaurant
{
    public class RestaurantContoller
    {
        private readonly RestaurantUseCases _restaurantUseCases;

        public RestaurantContoller(RestaurantUseCases restaurantUseCases)
        {
            _restaurantUseCases = restaurantUseCases;
        }

        public void AddItem(MenuItem menuItem)
        {
            _restaurantUseCases.AddMenuItem(menuItem);
        }

        public void UpdateItem(MenuItem menuItem)
        {
            _restaurantUseCases.UpdateItem(menuItem);
        }

        public void DeleteItem(string id)
        {
            _restaurantUseCases.DeleteItem(id);
        }

        public MenuItem GetMenuItemById(string id)
        {
            return _restaurantUseCases.GetMenuItemById(id);
        }

        public List<MenuItemViewModel> GetMenuItems()
        {
            return _restaurantUseCases.GetMenuItems();
        }

        public List<MenuItemViewModel> FilterItem(string keyword)
        {
            return _restaurantUseCases.FilterItem(keyword);
        }
    }
}
