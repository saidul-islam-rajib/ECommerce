using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Domain.Models;
using System.Reflection;

namespace Ordering.Infrastructure.Data
{
    /// <summary>
    /// Acts as a primary class that coordinates EF functionality for the data model
    /// </summary>
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        // 1. Develop constructor that will call from the base optoins
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        // 2. Create DbSet for entities
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();


        // 3. Override onModelCreating and apply configuration
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Grouping configuration in seperate class and Apply all those configurations from the assembly
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
