using CentFuxx.Products.Domain;
using CentFuxx.Products.Storage.EfCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CentFuxx.Products.Storage.EfCore
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
