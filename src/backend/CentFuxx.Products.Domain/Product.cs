using System;

namespace CentFuxx.Products.Domain
{
    public sealed class Product : Entity<long>
    {
        private Product() { }

        public Product(string name, string description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}
