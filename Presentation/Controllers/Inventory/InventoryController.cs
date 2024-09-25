using ESMART_HMS.Application.UseCases.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
