using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class MenuItemRepository : IBarItemRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public MenuItemRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddItem(Domain.Entities.MenuItem menuItem)
        {
            try
            {
                _db.MenuItems.Add(menuItem);
                _db.SaveChanges();
                MessageBox.Show("Successfully added item information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<BarItemViewModel> GetBarItems()
        {
            try
            {
                var allBarItems = from menuItem in _db.MenuItems.Where(b => b.IsTrashed == false && b.Section == "bar").OrderBy(b => b.DateCreated)
                                  select new BarItemViewModel
                                  {
                                      Id = menuItem.Id,
                                      BarItemId = menuItem.MenuItemId,
                                      Barcode = menuItem.Barcode,
                                      ItemName = menuItem.ItemName,
                                      Quantity = menuItem.Quantity.ToString(),
                                      Type = menuItem.Type,
                                      Measurement = menuItem.Measurement,
                                      CostPrice = menuItem.CostPrice.ToString(),
                                      SellingPrice = menuItem.SellingPrice.ToString(),
                                      CreatedBy = menuItem.ApplicationUser.FullName,
                                      DateCreated = menuItem.DateCreated.ToString(),
                                      DateModified = menuItem.DateModified.ToString(),
                                  };
                return allBarItems.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void UpdateBarItem(Domain.Entities.MenuItem menuItem)
        {
            try
            {
                _db.Entry(menuItem).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public Domain.Entities.MenuItem GetBarItemById(string id)
        {
            try
            {
                return _db.MenuItems.FirstOrDefault(bI => bI.Id == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public void DeleteBarItem(string id)
        {
            try
            {
                Domain.Entities.MenuItem menuItem = _db.MenuItems.FirstOrDefault(b => b.Id == id);
                if (menuItem != null)
                {
                    menuItem.IsTrashed = true;
                    _db.Entry(menuItem).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<BarItemViewModel> FilterBarItem(string keyword)
        {
            try
            {
                var allBarItems = from menuItem in _db.MenuItems.Where(b => b.IsTrashed == false && b.ItemName.Contains(keyword)).OrderBy(b => b.DateCreated)
                                  select new BarItemViewModel
                                  {
                                      Id = menuItem.Id,
                                      BarItemId = menuItem.MenuItemId,
                                      Barcode = menuItem.Barcode,
                                      ItemName = menuItem.ItemName,
                                      Quantity = menuItem.Quantity.ToString(),
                                      Type = menuItem.Type,
                                      Measurement = menuItem.Measurement,
                                      CostPrice = menuItem.CostPrice.ToString(),
                                      SellingPrice = menuItem.SellingPrice.ToString(),
                                      CreatedBy = menuItem.ApplicationUser.FullName,
                                      DateCreated = menuItem.DateCreated.ToString(),
                                      DateModified = menuItem.DateModified.ToString(),
                                  };
                return allBarItems.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
