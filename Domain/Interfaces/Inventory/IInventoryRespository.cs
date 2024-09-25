using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMART_HMS.Domain.Interfaces
{
    public interface IInventoryRespository
    {
        void AddItem(Domain.Entities.MenuItem item);
        void AddInventory(Domain.Entities.Inventory inventory);
    }
}
