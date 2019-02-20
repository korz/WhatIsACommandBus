using CommandBus.CommandBusCore.Commands;

namespace CommandBus.CommandBusCore.CommandHandlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
