using Domain.Entities;

namespace Domain.Ports.IOrderItem
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetOrListOrderItemAsync(int orderItemId);
        Task<OrderItem> InsertOrderItemAsync(OrderItem orderItem);
        Task<OrderItem> UpdateOrderItemAsync(OrderItem orderItem);
        Task<OrderItem> DeleteOrderItemAsync(int orderItemId);
        Task<IEnumerable<OrderItem>> ListOrderItemsByOrderIdAsync(int orderId);
    }
}
