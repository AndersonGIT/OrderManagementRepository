using Domain.Entities;
using Domain.Models;

namespace Domain.Ports.IOrder
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrListOrderAsync(int orderId);
        Task<IEnumerable<OrderOutput>> GetOrListOrderOutputAsync(int orderId);
        Task<Order> InsertOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> DeleteOrderAsync(int orderId);
        Task<double> GetTotalPriceAsync(Order order);
    }
}
