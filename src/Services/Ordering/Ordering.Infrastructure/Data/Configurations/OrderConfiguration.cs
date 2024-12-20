using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).HasConversion(
                orderId => orderId.Value,
                dbId => OrderId.Of(dbId));

            // one to many relationship with customer and order
            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .IsRequired();

            // many to one relationship with order item and order
            builder.HasMany(o => o.OrderItems)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId);

            builder.ComplexProperty(
                o => o.OrderName, nameBuilder =>
                {
                    nameBuilder.Property(n => n.Value)
                        .HasColumnName(nameof(Order.OrderName))
                        .HasMaxLength(100)
                        .IsRequired();
                });

            builder.ComplexProperty(
                o => o.ShippingAddress, addressBuilder =>
                {
                    addressBuilder.Property(ab => ab.FirstName)
                        .HasMaxLength(50)
                        .IsRequired();

                    addressBuilder.Property(ab => ab.LastName)
                        .HasMaxLength(50)
                        .IsRequired();

                    addressBuilder.Property(ab => ab.EmailAddress)
                        .HasMaxLength(50);

                    addressBuilder.Property(ab => ab.AddressLine)
                        .HasMaxLength(180)
                        .IsRequired();

                    addressBuilder.Property(ab => ab.Country)
                        .HasMaxLength(50);

                    addressBuilder.Property(ab => ab.State)
                        .HasMaxLength(50);

                    addressBuilder.Property(ab => ab.ZipCode)
                        .HasMaxLength(50)
                        .IsRequired();
                });

            builder.ComplexProperty(
                o => o.BillingAddress, billingAddress =>
                {
                    billingAddress.Property(ab => ab.FirstName)
                        .HasMaxLength(50)
                        .IsRequired();

                    billingAddress.Property(ab => ab.LastName)
                        .HasMaxLength(50)
                        .IsRequired();

                    billingAddress.Property(ab => ab.EmailAddress)
                        .HasMaxLength(50);

                    billingAddress.Property(ab => ab.AddressLine)
                        .HasMaxLength(180)
                        .IsRequired();

                    billingAddress.Property(ab => ab.Country)
                        .HasMaxLength(50);

                    billingAddress.Property(ab => ab.State)
                        .HasMaxLength(50);

                    billingAddress.Property(ab => ab.ZipCode)
                        .HasMaxLength(50)
                        .IsRequired();
                });

            builder.ComplexProperty(
                o => o.Payment, paymentBuilder =>
                {
                    paymentBuilder.Property(pb => pb.CardName).HasMaxLength(50);
                    paymentBuilder.Property(pb => pb.CardNumber).HasMaxLength(24).IsRequired();
                    paymentBuilder.Property(pb => pb.Expiration).HasMaxLength(10);
                    paymentBuilder.Property(pb => pb.CVV).HasMaxLength(3);
                    paymentBuilder.Property(pb => pb.PaymentMethod);
                });

            builder.Property(o => o.Status)
                .HasDefaultValue(OrderStatus.Draft)
                .HasConversion(
                os => os.ToString(),
                dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

            builder.Property(o => o.TotalPrice);
        }
    }
}
