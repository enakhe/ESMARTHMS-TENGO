using ESMART_HMS.Application.UseCases.Bar.Order;
using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Presentation.Controllers.Bar
{
    public class OrderController
    {
        private readonly OrderUseCases _orderUseCases;

        public OrderController(OrderUseCases orderUseCases)
        {
            _orderUseCases = orderUseCases;
        }

        public void AddOrder(Order order)
        {
            _orderUseCases.AddOrder(order);
        }

        public List<OrderViewModel> GetAllOrders()
        {
            return _orderUseCases.GetAllOrders();
        }

        public Order GetOrderById(string id)
        {
            return _orderUseCases.GetOrderById(id);
        }
    }
}
