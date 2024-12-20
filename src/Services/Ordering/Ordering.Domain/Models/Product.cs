namespace Ordering.Domain.Models
{
    public class Product : Entity<ProductId>
    {
        public string ProductName { get; private set; } = default!;
        public string Price { get; private set; } = default!;
    }
}
