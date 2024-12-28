using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Bar;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data.Bar
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public OrderRepository(ESMART_HMSDBEntities db)
        {
            _db = db;
        }

        public void AddOrder(Order order)
        {
            try
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        public List<OrderViewModel> GetAllOrders()
        {
            try
            {
                var allOrders = from orders in _db.Orders.Where(b => b.IsTrashed == false).OrderBy(b => b.OrderDate)
                                select new OrderViewModel
                                {
                                    Id = orders.Id,
                                    OrderId = orders.OrderId.ToString(),
                                    Item = orders.MenuItem.ItemName,
                                    Quantity = orders.Quantity.ToString(),
                                    Customer = orders.Guest.FullName,
                                    TotalAmount = orders.TotalAmount.ToString(),
                                    OrderDate = orders.OrderDate.ToString(),
                                    IssuedBy = orders.ApplicationUser.FullName
                                };
                return allOrders.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            return null;
        }

        public Order GetOrderById(string id)
        {
            try
            {
                return _db.Orders.FirstOrDefault(or => or.Id == id);
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
