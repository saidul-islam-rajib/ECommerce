namespace Catalog.API.Products.GetProductByCategory
{
    // public record GetProductByCategoryRequest();
    public record GetProductByCateogryResponse(IEnumerable<Product> Products);
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));
                var response = result.Adapt<GetProductByCateogryResponse>();
                return Results.Ok(response);
            }).WithName("GetProductByCategory")
                .Produces<GetProductByCateogryResponse>(StatusCodes.Status201Created)
                .WithSummary("Get Product By Category")
                .WithDescription("Get product by category are successfully completed.");
        }
    }
}
