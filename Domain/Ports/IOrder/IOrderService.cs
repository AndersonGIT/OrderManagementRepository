using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Ports.IOrder
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrListOrderAsync(int orderId);
        Task<Order> InsertOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> DeleteOrderAsync(int orderId);
    }
}
