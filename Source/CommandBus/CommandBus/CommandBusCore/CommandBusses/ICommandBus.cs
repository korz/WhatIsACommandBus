using CommandBus.CommandBusCore.Commands;

namespace CommandBus.CommandBusCore.CommandBusses
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
