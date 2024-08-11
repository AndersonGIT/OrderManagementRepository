using Domain.Entities;
using Domain.Ports.IProduct;
using Infraestructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Database.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> Delete(int productId)
        {
            var product = await _appDbContext.Product.FirstOrDefaultAsync(product => product.Id == productId);

            if (product?.Id > 0)
            {
                _appDbContext.Product.Remove(product);
                await _appDbContext.SaveChangesAsync();
                return product;
            }
            else
            {
                throw new ArgumentNullException(nameof(product));
            }
        }

        public async Task<IEnumerable<Product>> GetOrList(int productId)
        {
            List<Product> products = new List<Product>();
            if (productId > 0)
            {
                var product = await _appDbContext.Product.FirstOrDefaultAsync(product => product.Id == productId);

                if (product?.Id > 0)
                {
                    products.Add(product);
                }
            }
            else
            {
                products = await _appDbContext.Product.ToListAsync();
            }

            return products;
        }

        public async Task<Product> Insert(Product product)
        {
            if (product != null)
            {
                _appDbContext.Product.Add(product);
                await _appDbContext.SaveChangesAsync();
                return product;
            }
            else
            {
                throw new ArgumentNullException(nameof(product));
            }
        }

        public async Task<Product> Update(Product product)
        {
            if (product != null)
            {
                _appDbContext.Product.Update(product);
                await _appDbContext.SaveChangesAsync();
                return product;
            }
            else
            {
                throw new ArgumentNullException(nameof(product));
            }
        }
    }
}
