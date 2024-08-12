using Domain.Entities;

namespace Domain.Ports.IOrderItem
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> Delete(int orderItemId);
        Task<IEnumerable<OrderItem>> GetOrList(int orderItemId);
        Task<OrderItem> Insert(OrderItem orderItem);
        Task<OrderItem> Update(OrderItem orderItem);
        Task<IEnumerable<OrderItem>> ListOrderItemsByOrderId(int orderId);
    }
}
