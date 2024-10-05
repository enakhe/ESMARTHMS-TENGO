using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Inventory
{
    public class InventoryUseCases
    {
        private readonly IInventoryRespository _inventoryRespository;

        public InventoryUseCases(IInventoryRespository inventoryRespository)
        {
            _inventoryRespository = inventoryRespository;
        }

        public void AddMenuItem(Domain.Entities.MenuItem menuItem)
        {
            _inventoryRespository.AddItem(menuItem);
        }

        public void AddInventory(Domain.Entities.Inventory inventory)
        {
            _inventoryRespository.AddInventory(inventory);
        }

        public List<InventoryViewModel> GetAllInventory()
        {
            return _inventoryRespository.GetAllInventoryViewModels();
        }

        public List<InventoryViewModel> GetRecycledInventory()
        {
            return _inventoryRespository.GetRecycledInventoryViewModels();
        }

        public Domain.Entities.Inventory GetInventoryById(string id)
        {
            return _inventoryRespository.GetInventoryById(id);
        }

        public void UpdateInventory(Domain.Entities.Inventory inventory) 
        { 
            _inventoryRespository.UpdateInventory(inventory);
        }

        public void DeleteInventory(string id)
        {
            _inventoryRespository.DeleteInventory(id);
        }
    }
}
