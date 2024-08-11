using Domain.Ports.IClient;
using Domain.Ports.IOrder;
using Domain.Ports.IOrderItem;
using Domain.Ports.IProduct;
using Infraestructure.Database.Context;
using Infraestructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Database
{
    public static class DbBuilderExtensions
    {
        public static IServiceCollection AddDBInMemoryService(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AppInMemoryDB"));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            return services;
        }
    }
}
