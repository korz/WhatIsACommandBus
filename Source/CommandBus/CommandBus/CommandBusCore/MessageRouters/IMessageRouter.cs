using CommandBus.CommandBusCore.CommandHandlers;
using CommandBus.CommandBusCore.Commands;

namespace CommandBus.CommandBusCore.MessageRouters
{
    public interface IMessageRouter
    {
        ICommandHandler<TCommand> GetRoute<TCommand>() where TCommand : ICommand;
    }
}
