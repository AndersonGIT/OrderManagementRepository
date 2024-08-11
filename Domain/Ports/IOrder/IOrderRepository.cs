using Domain.Entities;

namespace Domain.Ports.IOrder
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrList(int orderId);
        Task<Order> Insert(Order order);
        Task<Order> Update(Order order);
        Task<Order> Delete(int orderId);
    }
}
