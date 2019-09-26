using Microsoft.EntityFrameworkCore;

namespace CentFuxx.Products.Storage.EfCore.MySql
{
    public class MySqlProductContext : ProductsContext
    {
        public MySqlProductContext(DbContextOptions options) : base(options)
        {
        }
    }
}
