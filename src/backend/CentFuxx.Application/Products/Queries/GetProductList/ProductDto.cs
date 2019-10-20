using System;
using System.Collections.Generic;
using System.Text;

namespace CentFuxx.Products.Application.Products.Queries.GetProductList
{
    public class ProductDto
    {
        public long? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
