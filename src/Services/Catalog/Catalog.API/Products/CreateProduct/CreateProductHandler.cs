using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    // represent the data that we need to create
    public record CreateProductCommand(
        string Name,
        List<string> Cateogry,
        string Description,
        string ImageFile,
        decimal Price) : IRequest<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // perform business logic to create a new product


            throw new NotImplementedException();
        }
    }
}
