using System.Threading.Tasks;
using CentFuxx.Products.Application.Products.Models;

namespace CentFuxx.Products.Application.Products.Queries.GetProductList
{
    public interface IGetProductListQuery
    {
        Task<ProductListModel> GetProductList();
    }
}