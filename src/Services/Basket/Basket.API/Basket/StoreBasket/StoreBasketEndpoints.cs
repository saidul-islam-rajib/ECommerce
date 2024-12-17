using Basket.API.Basket.GetBasket;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart Cart);
    public record StoreBasketResponse(string UserName);
    public class StoreBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket/", async (StoreBasketRequest request, ISender sender) =>
            {
                // 1. Adapt incoming `request` to `command` object
                var command = request.Adapt<StoreBasketCommand>();

                // 2. Send this `command` object through `mediatR`
                var result = await sender.Send(command);

                // 3. Adapt this `result` object to `response` object
                var response = result.Adapt<StoreBasketResponse>();

                // 4. Return to the client as a Result
                return Results.Created($"/basket/{response.UserName}", response);

            })
            .WithName("Create Basket")
            .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
            .WithSummary("Create Basket")
            .WithDescription("Create Basket");
        }
    }
}
