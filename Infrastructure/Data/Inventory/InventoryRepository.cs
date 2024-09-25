using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace ESMART_HMS.Infrastructure.Data.Inventory
{
    public class InventoryRepository : IInventoryRespository
    {
        private readonly ESMART_HMSDBEntities _db;

        public InventoryRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddItem(Domain.Entities.MenuItem item)
        {
            try
            {
                _db.MenuItems.Add(item);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public void AddInventory(Domain.Entities.Inventory inventory)
        {
            try
            {
                _db.Inventories.Add(inventory);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
    }
}
