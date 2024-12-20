using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // set primary key
            builder.HasKey(c => c.Id);

            // custom conversion `CustomerId` to `Id` value
            builder.Property(c => c.Id).HasConversion(
                customerId => customerId.Value,
                dbId => CustomerId.Of(dbId));
            
            // configuration other property
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(250);
            builder.HasIndex(c => c.Email).IsUnique();
            
        }
    }
}
