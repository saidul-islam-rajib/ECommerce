using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    Id = 1,
                    ProductName = "Samsung A54",
                    Description = "Samsung A54 has great features in it's camera, performance, throughput etc",
                    Amount = 150
                },
                new Coupon
                {
                    Id = 2,
                    ProductName = "IPhone X",
                    Description = "IPhone X has great features in it's camera, performance, throughput etc",
                    Amount = 250
                });
        }
    }
}
