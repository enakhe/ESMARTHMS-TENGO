using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Restaurant;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Restaurant
{
    public class RestaurantUseCases
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantUseCases(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            _repository.AddItem(menuItem);
        }

        public void UpdateItem(MenuItem menuItem)
        {
            _repository.UpdateMenuItem(menuItem);
        }

        public void DeleteItem(string id)
        {
            _repository.DeleteMenuItem(id);
        }

        public MenuItem GetMenuItemById(string id)
        {
            return _repository.GetMenuItemById(id);
        }

        public List<MenuItemViewModel> GetMenuItems()
        {
            return _repository.GetMenuItems();
        }

        public List<MenuItemViewModel> FilterItem(string keyword)
        {
            return _repository.FilterMenuItem(keyword);
        }
    }
}
