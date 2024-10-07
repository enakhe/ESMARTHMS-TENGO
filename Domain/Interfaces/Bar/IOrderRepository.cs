using ESMART_HMS.Domain.Entities;

namespace ESMART_HMS.Domain.Interfaces.Bar
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
    }
}
