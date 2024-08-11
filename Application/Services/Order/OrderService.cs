using Domain.Ports.IOrder;
using Domain.Ports.IOrderItem;

namespace Application.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<Domain.Entities.Order> DeleteOrderAsync(int clientId)
        {
            var orderDeleted = await _orderRepository.Delete(clientId);
            return orderDeleted;
        }

        public async Task<IEnumerable<Domain.Entities.Order>> GetOrListOrderAsync(int orderId)
        {
            var orders = await _orderRepository.GetOrList(orderId);

            foreach(var order in orders)
            {
                var orderItems = await _orderItemRepository.ListOrderItemsByOrderId(order.Id);
                order.OrderItems = orderItems.ToList();
            }
            
            return orders;
        }

        public async Task<Domain.Entities.Order> InsertOrderAsync(Domain.Entities.Order order)
        {
            var orderInserted = await _orderRepository.Insert(order);

            return orderInserted;
        }

        public async Task<Domain.Entities.Order> UpdateOrderAsync(Domain.Entities.Order order)
        {
            var orderUpdated = await _orderRepository.Update(order);
            return orderUpdated;
        }
    }
}
