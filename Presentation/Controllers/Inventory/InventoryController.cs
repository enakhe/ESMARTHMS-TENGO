using ESMART_HMS.Application.UseCases.Inventory;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers.Inventory
{
    public class InventoryController
    {
        private readonly InventoryUseCases _inventoryUseCases;

        public InventoryController(InventoryUseCases inventoryUseCases)
        {
            _inventoryUseCases = inventoryUseCases;
        }

        public void AddItem(Domain.Entities.MenuItem menuItem)
        {
            _inventoryUseCases.AddMenuItem(menuItem);
        }

        public void AddInventory(Domain.Entities.Inventory inventory)
        {
            _inventoryUseCases.AddInventory(inventory);
        }

        public List<InventoryViewModel> GetInventoryViewModels()
        {
            return _inventoryUseCases.GetAllInventory();
        }

        public Domain.Entities.Inventory GetInventoryById(string id)
        {
            return _inventoryUseCases.GetInventoryById(id);
        }

        public void UpdateInventory(Domain.Entities.Inventory inventory)
        {
            _inventoryUseCases.UpdateInventory(inventory);
        }

        public List<InventoryViewModel> GetRecycledInventory()
        {
            return _inventoryUseCases.GetRecycledInventory();
        }

        public void DeleteInventory(string id)
        {
            _inventoryUseCases.DeleteInventory(id);
        }
    }

}
