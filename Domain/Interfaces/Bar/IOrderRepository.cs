using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Domain.Interfaces.Bar
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        List<OrderViewModel> GetAllOrders();
        Order GetOrderById(string id);
    }
}
