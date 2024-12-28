using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IInventoryRespository
    {
        void AddItem(Domain.Entities.MenuItem item);
        void AddInventory(Domain.Entities.Inventory inventory);
        List<InventoryViewModel> GetAllInventoryViewModels();
        Domain.Entities.Inventory GetInventoryById(string id);
        void UpdateInventory(Domain.Entities.Inventory inventory);
        List<InventoryViewModel> GetRecycledInventoryViewModels();
        void DeleteInventory(string id);
        List<MenuItemViewModel> GetStoreItems();
    }
}
