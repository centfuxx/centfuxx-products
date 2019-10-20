using System.Collections.Generic;
using System.Threading.Tasks;
using CentFuxx.Products.Domain.Products;

namespace CentFuxx.Products.Application.Repositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<Product> Get(long id);
    }
}
