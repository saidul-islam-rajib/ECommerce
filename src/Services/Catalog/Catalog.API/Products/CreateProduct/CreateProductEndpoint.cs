﻿namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(
        string Name,
        List<string> Cateogry,
        string Description,
        string ImageFile,
        decimal Price);

    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (
                CreateProductRequest request,
                ISender sender) =>
            {
                // convert into `command` from `request`, then send it through mediator to get `result`, and then this `result` will convert into `response`
                var command = request.Adapt<CreateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response);
            }).WithName("CreateProduct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .WithSummary("Create Product")
                .WithDescription("Product created successfully");
        }
    }
}
