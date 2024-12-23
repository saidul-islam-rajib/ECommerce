namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderHandler(IApplicationDbContext dbContext)
        : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            // 1. Delete order entity from command object
            var orderId = OrderId.Of(command.OrderId);
            var order = await dbContext.Orders.FindAsync([orderId], cancellationToken: cancellationToken);
            if(order is null)
            {
                throw new OrderNotFoundException(command.OrderId);
            }

            // 2. Save to database
            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            // 3. Return result
            return new DeleteOrderResult(true);
        }
    }
}
