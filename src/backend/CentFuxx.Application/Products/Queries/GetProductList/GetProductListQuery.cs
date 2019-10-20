using System;
using System.Linq;
using System.Threading.Tasks;
using CentFuxx.Products.Application.Repositories;
using CentFuxx.Products.Domain.Products;

namespace CentFuxx.Products.Application.Products.Queries.GetProductList
{
    public sealed class GetProductListQuery : IGetProductListQuery
    {
        private readonly IProductsRepository _repository;

        public GetProductListQuery(IProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductListModel> GetProductList()
        {
            var products = await _repository.GetAll();
            return new ProductListModel()
            {
                Products = products.Select(x => new ProductDto() {Id = x.Id, Name = x.Name, Description = x.Description})
            };
        }
    }
}
