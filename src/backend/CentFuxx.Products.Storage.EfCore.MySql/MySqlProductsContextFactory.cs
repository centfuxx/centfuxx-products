using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CentFuxx.Products.Storage.EfCore.MySql
{
    public class MySqlProductsContextFactory : IDesignTimeDbContextFactory<MySqlProductContext>
    {
        public MySqlProductContext CreateDbContext(string[] args)
        {// Build config
            var _configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables("CENTFUXXPRODUCTS_")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<MySqlProductContext>();
            optionsBuilder.UseMySql(_configuration.GetConnectionString("MySQL"));
            return new MySqlProductContext(optionsBuilder.Options);
        }
    }
}
