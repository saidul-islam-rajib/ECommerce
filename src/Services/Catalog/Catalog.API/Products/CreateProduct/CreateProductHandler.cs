using BuildingBlocks.CQRS;
using Catalog.API.Models;

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
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
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
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);             
        }
    }
}
