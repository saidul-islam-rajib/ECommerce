using MediatR;

namespace BuildingBlocks.CQRS
{
    // if we do not need any response then use following ICommandHandler interface
    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
        where TCommand : ICommand<Unit>
    {

    }

    // if we need to return response then use following ICommandHandler interface
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}
