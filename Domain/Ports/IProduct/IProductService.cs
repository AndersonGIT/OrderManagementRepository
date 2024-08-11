using Domain.Entities;

namespace Domain.Ports.IProduct
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetOrListProductAsync(int productId);
        Task<Product> InsertProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> DeleteProductAsync(int productId);
    }
}
