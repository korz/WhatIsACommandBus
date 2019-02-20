using Cqrs.CommandBusCore.CommandHandlers;
using Cqrs.CommandBusCore.Commands;
using Cqrs.CommandBusCore.Queries;
using Cqrs.CommandBusCore.QueryHandlers;

namespace Cqrs.CommandBusCore.MessageRouters
{
    public interface IMessageRouter
    {
        ICommandHandler<TCommand> GetRoute<TCommand>() where TCommand : ICommand;
        IQueryHandler<TQuery, TResult> GetRoute<TQuery, TResult>() where TQuery : IQuery<TResult>;
    }
}
