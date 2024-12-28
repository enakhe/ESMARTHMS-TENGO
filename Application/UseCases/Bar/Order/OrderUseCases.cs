using ESMART_HMS.Domain.Interfaces.Bar;
using ESMART_HMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace ESMART_HMS.Application.UseCases.Bar.Order
{
    public class OrderUseCases
    {
        private readonly IOrderRepository _orderRepository;

        public OrderUseCases(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddOrder(Domain.Entities.Order order)
        {
            _orderRepository.AddOrder(order);
        }

        public List<OrderViewModel> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Domain.Entities.Order GetOrderById(string id)
        { 
            return _orderRepository.GetOrderById(id);
        }
    }
}
