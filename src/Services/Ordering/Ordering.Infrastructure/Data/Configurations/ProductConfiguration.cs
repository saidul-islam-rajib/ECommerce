using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // set primary key
            builder.HasKey(p => p.Id);

            // custom conversion `ProductId` to `Id` value
            builder.Property(p => p.Id).HasConversion(
                productId => productId.Value,
                dbId => ProductId.Of(dbId));

            // configuration other property
            builder.Property(p => p.ProductName).HasMaxLength(100).IsRequired();
        }
    }
}
