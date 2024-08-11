using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace Infraestructure.Database.Context
{
    public static class InitializeDefaultDatabase
    {
        public static async void Init(IApplicationBuilder applicationBuilder)
        {
            try
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    var myInMemoryContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

                    if (myInMemoryContext != null)
                    {
                        myInMemoryContext.Database.EnsureCreated();

                        if (!myInMemoryContext.Client.Any())
                        {
                            myInMemoryContext.Client.AddRange(
                                    new Client(name: "Anderson Client", email: "anderson.client@email.com"),
                                    new Client(name: "Diego Client", email: "diego.client@email.com"),
                                    new Client(name: "Jose Client", email: "jose.client@email.com")
                                );
                            await myInMemoryContext.SaveChangesAsync();
                        }

                        if (!myInMemoryContext.Product.Any())
                        {
                            myInMemoryContext.Product.AddRange(
                                    new Product(name: "Tshirt Blue", price: 17.99),
                                    new Product(name: "Small Collection Car", price: 147.50),
                                    new Product(name: "White Belt", price: 5.99)
                                );
                            await myInMemoryContext.SaveChangesAsync();
                        }

                        if (!myInMemoryContext.Order.Any())
                        {
                            var orderItems = new List<OrderItem>();

                            orderItems.AddRange([
                                    new OrderItem(orderId: 1, productId: 1, quantity: 8),
                                    new OrderItem(orderId: 1, productId: 2, quantity: 5),
                                    new OrderItem(orderId: 1, productId: 3, quantity: 10)
                                ]);

                            myInMemoryContext.Order.AddRange(
                                    new Order(clientId: 1, paymentStatus: true, orderItems)
                                );
                            await myInMemoryContext.SaveChangesAsync();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
