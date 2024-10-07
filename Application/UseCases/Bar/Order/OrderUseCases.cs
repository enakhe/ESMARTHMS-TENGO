using ESMART_HMS.Domain.Interfaces.Bar;

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
    }
}
