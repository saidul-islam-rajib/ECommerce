namespace Ordering.Domain.Models
{
    public class Product : Entity<Guid>
    {
        public string ProductName { get; private set; } = default!;
        public string Price { get; private set; } = default!;
    }
}
