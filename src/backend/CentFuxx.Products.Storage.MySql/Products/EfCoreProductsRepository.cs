using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentFuxx.Products.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace CentFuxx.Products.Storage.EfCore.Products
{
    public class EfCoreProductsRepository : ProductsRepository
    {
        private readonly ProductsContext _context;

        public EfCoreProductsRepository(ProductsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Product> Add(Product product)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                await _context.Products.AddAsync(product);
                _context.SaveChanges();
                transaction.Commit();
            }

            return product;
        }

        public async Task<Product> Update(Product product)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.Products.Attach(product);
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                transaction.Commit();

                return product;
            }
        }
    }
}
