using Domain.Entities;

namespace Domain.Ports.IProduct
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetOrList(int productId);
        Task<Product> Insert(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(int productId);
    }
}
