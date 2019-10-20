using System.Collections.Generic;
using CentFuxx.Products.Application.Products.Queries.GetProductList;

namespace CentFuxx.Products.Application.Products.Models
{
    public class ProductListModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}