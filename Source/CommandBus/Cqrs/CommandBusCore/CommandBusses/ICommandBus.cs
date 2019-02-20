using Cqrs.CommandBusCore.Commands;
using Cqrs.CommandBusCore.Queries;

namespace Cqrs.CommandBusCore.CommandBusses
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
        TResult Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
