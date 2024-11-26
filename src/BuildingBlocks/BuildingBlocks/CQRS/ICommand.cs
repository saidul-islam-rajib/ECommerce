using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommand : ICommand<Unit>
    {
        // does not return any response
    }
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
