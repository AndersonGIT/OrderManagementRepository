using Domain.Ports.IOrderItem;

namespace Application.Services.OrderItem
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderItemService(IOrderItemRepository orderItemRepository) => _orderItemRepository = orderItemRepository;

        public async Task<Domain.Entities.OrderItem> DeleteOrderItemAsync(int orderItemId)
        {
            var orderItemDeleted = await _orderItemRepository.Delete(orderItemId);
            return orderItemDeleted;
        }

        public async Task<IEnumerable<Domain.Entities.OrderItem>> GetOrListOrderItemAsync(int orderItemId)
        {
            var orderItems = await _orderItemRepository.GetOrList(orderItemId);
            return orderItems;
        }

        public async Task<Domain.Entities.OrderItem> InsertOrderItemAsync(Domain.Entities.OrderItem orderItem)
        {
            var orderItemInserted = await _orderItemRepository.Insert(orderItem);
            return orderItemInserted;
        }

        public async Task<Domain.Entities.OrderItem> UpdateOrderItemAsync(Domain.Entities.OrderItem orderItem)
        {
            var orderItemUpdated = await _orderItemRepository.Update(orderItem);
            return orderItemUpdated;
        }

        public async Task<IEnumerable<Domain.Entities.OrderItem>> ListOrderItemsByOrderIdAsync(int orderId)
        {
            var orderItems = await _orderItemRepository.ListOrderItemsByOrderId(orderId);
            return orderItems;
        }
    }
}
