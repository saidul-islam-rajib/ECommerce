namespace Ordering.Domain.Models
{
    public class Product : Entity<ProductId>
    {
        public string ProductName { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;

        public static Product Create(ProductId id, string name, decimal price)
        {
            // Domain validations
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

            Product product = new Product
            {
                Id = id,
                ProductName = name,
                Price = price,
            };

            return product;
        }
    }
}
