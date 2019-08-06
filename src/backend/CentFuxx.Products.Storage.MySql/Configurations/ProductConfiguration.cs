using System;
using CentFuxx.Products.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentFuxx.Products.Storage.EfCore.Configurations
{
    public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasColumnName("name").IsRequired().IsUnicode();
            builder.Property(x => x.Description).HasColumnName("description").IsUnicode();
        }
    }
}
