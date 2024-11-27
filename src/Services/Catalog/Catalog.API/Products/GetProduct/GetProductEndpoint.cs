namespace Catalog.API.Products.GetProduct
{
    // public record GetProductsRequest();

    public record GetProductsResponse(IEnumerable<Product> Products);

    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            }).WithName("GetProducts")
                .Produces<GetProductsResponse>(StatusCodes.Status201Created)
                .WithSummary("Get Products")
                .WithDescription("Getting all products are successfully completed.");
        }
    }
}
