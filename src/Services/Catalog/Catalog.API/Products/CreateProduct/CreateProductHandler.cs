using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    // represent the data that we need to create
    public record CreateProductCommand(
        string Name,
        List<string> Cateogry,
        string Description,
        string ImageFile,
        decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Cateogry,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            // TO DO : Save into DB

            return new CreateProductResult(Guid.NewGuid());             
        }
    }
}
