using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using ESMART_HMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class BarItemRepository : IBarItemRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public BarItemRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddItem(BarItem barItem)
        {
            try
            {
                _db.BarItems.Add(barItem);
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
                var allBarItems = from barItem in _db.BarItems.Where(b => b.IsTrashed == false).OrderBy(b => b.DateCreated)
                                  select new BarItemViewModel
                                  {
                                      Id = barItem.Id,
                                      BarItemId = barItem.BarItemId,
                                      Barcode = barItem.Barcode,
                                      ItemName = barItem.ItemName,
                                      Quantity = barItem.Quantity.ToString(),
                                      Type = barItem.Type,
                                      Measurement = barItem.Measurement,
                                      CostPrice = barItem.CostPrice.ToString(),
                                      SellingPrice = barItem.SellingPrice.ToString(),
                                      CreatedBy = barItem.ApplicationUser.FullName,
                                      DateCreated = barItem.DateCreated,
                                      DateModified = barItem.DateModified,
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
