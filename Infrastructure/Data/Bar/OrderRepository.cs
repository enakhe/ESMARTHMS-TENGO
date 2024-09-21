using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces.Bar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
