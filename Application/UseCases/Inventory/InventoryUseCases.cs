using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
