using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CentFuxx.Products.Storage.EfCore.MySql
{
    public class MySqlProductContext : ProductsContext
    {
        public MySqlProductContext(DbContextOptions options) : base(options)
        {
        }
    }
}
