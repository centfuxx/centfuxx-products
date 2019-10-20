using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentFuxx.Products.Application.Products.Queries.GetProductList;
using CentFuxx.Products.Application.Repositories;
using CentFuxx.Products.Storage.EfCore.Products;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;

namespace CentFuxx.Products
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IGetProductListQuery, GetProductListQuery>();
            services.AddScoped<IProductsRepository, EfCoreProductsRepository>();

            return services;
        }
    }
}
