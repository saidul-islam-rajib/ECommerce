﻿namespace Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger)
        : INotificationHandler<OrderUpdatedEvent>
    {
        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Domain Event handled : {notification.GetType().Name}");
            return Task.CompletedTask;
        }
    }
}
