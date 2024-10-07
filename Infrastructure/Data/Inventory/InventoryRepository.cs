using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

        public List<InventoryViewModel> GetAllInventoryViewModels()
        {
            try
            {
                var allInventory = _db.Inventories
                                      .Where(inv => !inv.IsTrashed)
                                      .OrderBy(inv => inv.MenuItem.ItemName)
                                      .Select(inventory => new InventoryViewModel
                                      {
                                          Id = inventory.Id,
                                          ItemName = inventory.MenuItem.ItemName,
                                          CostPrice = inventory.MenuItem.CostPrice.ToString(),
                                          SellingPrice = inventory.MenuItem.SellingPrice.ToString(),
                                          Category = inventory.MenuItem.Category.ToString(),
                                          Quantity = inventory.MenuItem.Quantity.ToString(),
                                          CurrentStock = inventory.CurrentStock.ToString(),
                                          InitialStock = inventory.InitialStock.ToString(),
                                          LowStockThreshold = inventory.LowStockThreshold.ToString(),
                                          CreatedBy = inventory.ApplicationUser.FullName,
                                          DateCreated = inventory.DateCreated.ToString(),
                                          DateModified = inventory.DateModified.ToString()
                                      })
                                      .ToList();
                return allInventory;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching inventory data.", ex);
            }
        }

        public Domain.Entities.Inventory GetInventoryById(string id)
        {
            try
            {
                return _db.Inventories.FirstOrDefault(inv => inv.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching inventory data.", ex);
            }
        }

        public void UpdateInventory(Domain.Entities.Inventory inventory)
        {
            try
            {
                _db.Entry(inventory).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating inventory data.", ex);
            }
        }

        public List<InventoryViewModel> GetRecycledInventoryViewModels()
        {
            try
            {
                var allInventory = _db.Inventories
                                      .Where(inv => inv.IsTrashed)
                                      .OrderBy(inv => inv.MenuItem.ItemName)
                                      .Select(inventory => new InventoryViewModel
                                      {
                                          Id = inventory.Id,
                                          ItemName = inventory.MenuItem.ItemName,
                                          CostPrice = inventory.MenuItem.CostPrice.ToString(),
                                          SellingPrice = inventory.MenuItem.SellingPrice.ToString(),
                                          Category = inventory.MenuItem.Category.ToString(),
                                          Quantity = inventory.MenuItem.Quantity.ToString(),
                                          CurrentStock = inventory.CurrentStock.ToString(),
                                          InitialStock = inventory.InitialStock.ToString(),
                                          LowStockThreshold = inventory.LowStockThreshold.ToString(),
                                          CreatedBy = inventory.ApplicationUser.FullName,
                                          DateCreated = inventory.DateCreated.ToString(),
                                          DateModified = inventory.DateModified.ToString()
                                      })
                                      .ToList();
                return allInventory;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching inventory data.", ex);
            }
        }

        public void DeleteInventory(string id)
        {
            try
            {
                Domain.Entities.Inventory inventory = GetInventoryById(id);
                inventory.IsTrashed = true;
                _db.Entry(inventory).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleteing inventory data.", ex);
            }
        }
    }
}
