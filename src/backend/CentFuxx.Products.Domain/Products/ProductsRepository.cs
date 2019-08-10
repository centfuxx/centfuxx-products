using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentFuxx.Products.Domain.Products
{
    public interface ProductsRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Add(Product product);
    }
}
