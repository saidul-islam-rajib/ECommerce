using Ordering.Application.Orders.Commands.CreateOrder;
namespace Ordering.API.Endpoints;

/// <summary>
/// Acecept `CreateOrderRequest` object
/// Adapt request to `CreateOrderCommand`
/// Uses `MediatR` to send the command to the corresponding handler
/// Adapt result object to the `CreateOrderResponse` object
/// Return `response` object to the `client` application
/// </summary>

public record CreateOrderRequest(OrderDto Order);
public record CreateOrderResponse(Guid Id);

public class CreateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateOrderCommand>();
            var result = await sender.Send(command);
            var respones = result.Adapt<CreateOrderResponse>();

            return Results.Created($"/orders/{respones.Id}", respones);
        })
        .WithName("CreateOrder")
        .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Order")
        .WithDescription("Create Order");
    }
}
