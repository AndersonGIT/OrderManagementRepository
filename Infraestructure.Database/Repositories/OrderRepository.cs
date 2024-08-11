using Domain.Entities;
using Domain.Ports.IOrder;
using Infraestructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Database.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Order> Delete(int orderId)
        {
            var order = await _appDbContext.Order.FirstOrDefaultAsync(order => order.Id == orderId);

            if (order?.Id > 0)
            {
                _appDbContext.Order.Remove(order);
                await _appDbContext.SaveChangesAsync();
                return order;
            }
            else
            {
                throw new ArgumentNullException(nameof(Order));
            }
        }

        public async Task<IEnumerable<Order>> GetOrList(int orderId)
        {
            if (orderId > 0)
            {
                var orders = _appDbContext.Order.Where(order => order.Id == orderId).ToList();
                return orders;
            }
            else
            {
                var orders = await _appDbContext.Order.ToListAsync();
                return orders;
            }
        }

        public async Task<Order> Insert(Order Order)
        {
            if (Order != null)
            {
                _appDbContext.Order.Add(Order);
                await _appDbContext.SaveChangesAsync();
                return Order;
            }
            else
            {
                throw new ArgumentNullException(nameof(Order));
            }
        }

        public async Task<Order> Update(Order Order)
        {
            if (Order != null)
            {
                _appDbContext.Order.Update(Order);
                await _appDbContext.SaveChangesAsync();
                return Order;
            }
            else
            {
                throw new ArgumentNullException(nameof(Order));
            }
        }
    }
}
