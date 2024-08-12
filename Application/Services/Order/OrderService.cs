using Domain.Models;
using Domain.Ports.IClient;
using Domain.Ports.IOrder;
using Domain.Ports.IOrderItem;
using Domain.Ports.IProduct;

namespace Application.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemService _orderItemService;
        private readonly IProductService _productService;
        private readonly IClientService _clientService;
        public OrderService(IOrderRepository orderRepository, IOrderItemService orderItemService, IProductService productService, IClientService clientService)
        {
            _orderRepository = orderRepository;
            _orderItemService = orderItemService;
            _productService = productService;
            _clientService = clientService;
        }

        public async Task<Domain.Entities.Order> DeleteOrderAsync(int clientId)
        {
            var orderDeleted = await _orderRepository.Delete(clientId);
            return orderDeleted;
        }

        public async Task<IEnumerable<Domain.Entities.Order>> GetOrListOrderAsync(int orderId)
        {
            var orders = await _orderRepository.GetOrList(orderId);

            foreach (var order in orders)
            {
                var orderitems = await _orderItemService.ListOrderItemsByOrderIdAsync(order.Id);
                order.OrderItems = orderitems.ToList();
                order.TotalPrice = await GetTotalPriceAsync(order);
            }

            return orders;
        }

        public async Task<Domain.Entities.Order> InsertOrderAsync(Domain.Entities.Order order)
        {
            if (order != null)
            {
                order.TotalPrice = await GetTotalPriceAsync(order);
                var orderInserted = await _orderRepository.Insert(order);
                return orderInserted;
            }

            return order;
        }

        public async Task<Domain.Entities.Order> UpdateOrderAsync(Domain.Entities.Order order)
        {

            if (order != null)
            {
                order.TotalPrice = await GetTotalPriceAsync(order);
                var orderUpdated = await _orderRepository.Update(order);
                return orderUpdated;
            }

            return order;
        }

        public async Task<double> GetTotalPriceAsync(Domain.Entities.Order order)
        {
            double totalPrice = 0;

            if (order != null)
            {
                foreach (var orderItem in order.OrderItems)
                {
                    var product = await _productService.GetOrListProductAsync(orderItem.ProductId);

                    var productPrice = product.First().Price;

                    totalPrice += (productPrice * orderItem.Quantity);
                }
            }

            return totalPrice;
        }

        private async Task<OrderOutput> ConvertOrderIntoOrderOutput(Domain.Entities.Order order)
        {
            OrderOutput orderOutput = new OrderOutput();

            var clientList = await _clientService.GetOrListClientAsync(order.ClientId);
            var client = clientList?.First();

            if (client != null)
            {
                orderOutput.ClientEmail = client.Email;
                orderOutput.ClientName = client.Name;
            }

            var orderItems = await _orderItemService.ListOrderItemsByOrderIdAsync(order.Id);

            List<OrderItemOutput> orderItemsOutput = new List<OrderItemOutput>();

            foreach (var orderItem in orderItems)
            {
                var productList = await _productService.GetOrListProductAsync(orderItem.ProductId);
                var product = productList?.First();

                if (product != null)
                {
                    if (product.Id == orderItem.ProductId)
                    {
                        orderItemsOutput.Add(
                            new OrderItemOutput(
                                id: orderItem.Id,
                                productId: product.Id,
                                productName: product.Name,
                                productPrice: product.Price,
                                quantity: orderItem.Quantity
                        ));
                    }
                }
            }
            orderOutput.Id = order.Id;
            orderOutput.PaymentStatus = order.PaymentStatus;
            orderOutput.TotalPrice = await GetTotalPriceAsync(order);
            orderOutput.OrderItems = orderItemsOutput;

            return orderOutput;
        }

        public async Task<IEnumerable<OrderOutput>> GetOrListOrderOutputAsync(int orderId)
        {
            var orders = await GetOrListOrderAsync(orderId);
            var ordersOutput = new List<OrderOutput>();

            if(orders != null)
            {
                foreach (var order in orders)
                {
                    var orderOutput = await ConvertOrderIntoOrderOutput(order);
                    ordersOutput.Add(orderOutput);
                }

            }

            return ordersOutput;
        }
    }
}
