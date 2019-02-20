using Cqrs.CommandBusCore.Commands;

namespace Cqrs.CommandBusCore.CommandHandlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
