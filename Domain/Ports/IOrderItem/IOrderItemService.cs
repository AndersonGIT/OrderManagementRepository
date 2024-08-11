using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
