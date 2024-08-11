using Application.Services.Client;
using Application.Services.Order;
using Application.Services.OrderItem;
using Application.Services.Product;
using Domain.Ports.IClient;
using Domain.Ports.IOrder;
using Domain.Ports.IOrderItem;
using Domain.Ports.IProduct;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServicesBuilderExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderItemService, OrderItemService>();

            return services;         
        } 
    }
}
