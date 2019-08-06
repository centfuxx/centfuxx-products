using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentFuxx.Products.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace CentFuxx.Products.Storage.EfCore
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
    }
}
