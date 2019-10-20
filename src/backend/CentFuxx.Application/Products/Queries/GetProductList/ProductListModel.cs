using System.Collections.Generic;

namespace CentFuxx.Products.Application.Products.Queries.GetProductList
{
    public class ProductListModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}