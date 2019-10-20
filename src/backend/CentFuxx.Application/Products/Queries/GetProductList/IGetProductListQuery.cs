using System.Threading.Tasks;

namespace CentFuxx.Products.Application.Products.Queries.GetProductList
{
    public interface IGetProductListQuery
    {
        Task<ProductListModel> GetProductList();
    }
}