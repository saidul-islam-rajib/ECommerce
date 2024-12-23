namespace Ordering.Application.Orders.Queries.GetOrdersByName
{
    public class GetOrdersByNameHandler(IApplicationDbContext dbContext)
        : IQueryHandler<GetOrdersByName, GetOrdersByNameResult>
    {
        public async Task<GetOrdersByNameResult> Handle(GetOrdersByName query, CancellationToken cancellationToken)
        {
            // 1. Get orders by name using dbContext
            var orders = await dbContext.Orders
                .Include(o => o.OrderItems).AsNoTracking()
                .Where(o => o.OrderName.Value.Contains(query.Name))
                .OrderBy(o => o.OrderName)
                .ToListAsync();

            var orderDtos = ProjectToOrderDto(orders);

            // 2. Return result
            return new GetOrdersByNameResult(orderDtos);
        }

        private IEnumerable<OrderDto> ProjectToOrderDto(List<Order> orders)
        {
            List<OrderDto> result = new();
            foreach (var order in orders)
            {
                var shippingAddress = new AddressDto(
                    order.ShippingAddress.FirstName,
                    order.ShippingAddress.LastName,
                    order.ShippingAddress.EmailAddress,
                    order.ShippingAddress.AddressLine,
                    order.ShippingAddress.Country,
                    order.ShippingAddress.State,
                    order.ShippingAddress.ZipCode);

                var billingAddress = new AddressDto(
                    order.BillingAddress.FirstName,
                    order.BillingAddress.LastName,
                    order.BillingAddress.EmailAddress,
                    order.BillingAddress.AddressLine,
                    order.BillingAddress.Country,
                    order.BillingAddress.State,
                    order.BillingAddress.ZipCode);

                var payment = new PaymentDto(
                    order.Payment.CardName,
                    order.Payment.CardNumber,
                    order.Payment.Expiration,
                    order.Payment.CVV,
                    order.Payment.PaymentMethod);

                var orderItems = order.OrderItems.Select(oi => new OrderItemDto(
                    oi.OrderId.Value,
                    oi.ProductId.Value,
                    oi.Quantity,
                    oi.Price)).ToList();


                var orderDto = new OrderDto(
                    Id: order.Id.Value,
                    CustomerId: order.CustomerId.Value,
                    OrderName: order.OrderName.Value,
                    ShippingAddress: shippingAddress,
                    BillingAddress: billingAddress,
                    Payment: payment,
                    Status: order.Status,
                    OrderItems: orderItems);

                result.Add(orderDto);
            }

            return result;
        }
    }
}
