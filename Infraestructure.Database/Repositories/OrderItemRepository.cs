using Domain.Entities;
using Domain.Ports.IOrderItem;
using Infraestructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Database.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<OrderItem> Delete(int orderItemId)
        {
            var orderItem = await _appDbContext.OrderItem.FirstOrDefaultAsync(orderItem => orderItem.Id == orderItemId);

            if (orderItem?.Id > 0)
            {
                _appDbContext.OrderItem.Remove(orderItem);
                await _appDbContext.SaveChangesAsync();
                return orderItem;
            }
            else
            {
                throw new ArgumentNullException(nameof(OrderItem));
            }
        }

        public async Task<IEnumerable<OrderItem>> GetOrList(int ordeItemId)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            if (ordeItemId > 0)
            {
                var orderItem = await _appDbContext.OrderItem.FirstOrDefaultAsync(client => client.Id == ordeItemId);

                if (orderItem?.Id > 0)
                {
                    orderItems.Add(orderItem);
                }
            }
            else
            {
                orderItems = await _appDbContext.OrderItem.ToListAsync();
            }

            return orderItems;
        }

        public async Task<OrderItem> Insert(OrderItem orderItem)
        {
            if (orderItem != null)
            {
                _appDbContext.OrderItem.Add(orderItem);
                await _appDbContext.SaveChangesAsync();
                return orderItem;
            }
            else
            {
                throw new ArgumentNullException(nameof(orderItem));
            }
        }

        public async Task<OrderItem> Update(OrderItem orderItem)
        {
            if (orderItem != null)
            {
                _appDbContext.OrderItem.Update(orderItem);
                await _appDbContext.SaveChangesAsync();
                return orderItem;
            }
            else
            {
                throw new ArgumentNullException(nameof(orderItem));
            }
        }

        public async Task<IEnumerable<OrderItem>> ListOrderItemsByOrderId(int orderId)
        {
            if (orderId >= 1)
            {
                List<OrderItem> orderItems = _appDbContext.OrderItem.Where(orderItem => orderItem.OrderId == orderId).ToList();
                return orderItems;
            }
            else
            {
                throw new ArgumentNullException(nameof(OrderItem));
            }
        }
    }
}
