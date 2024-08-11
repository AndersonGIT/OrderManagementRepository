using Domain.Ports.IProduct;

namespace Application.Services.Product
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<Domain.Entities.Product> DeleteProductAsync(int clientId)
        {
            var productDeleted = await _productRepository.Delete(clientId);
            return productDeleted;
        }

        public async Task<IEnumerable<Domain.Entities.Product>> GetOrListProductAsync(int productId)
        {
            var products = await _productRepository.GetOrList(productId);
            return products;
        }

        public async Task<Domain.Entities.Product> InsertProductAsync(Domain.Entities.Product product)
        {
            var productInserted = await _productRepository.Insert(product);
            return productInserted;
        }

        public async Task<Domain.Entities.Product> UpdateProductAsync(Domain.Entities.Product product)
        {
            var productUpdated = await _productRepository.Update(product);
            return productUpdated;
        }
    }
}
