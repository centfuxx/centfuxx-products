using AutoMapper;

namespace CentFuxx.Products.Api.Products
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Domain.Products.Product, Product>();
            CreateMap<Product, Domain.Products.Product>();
        }
    }
}
