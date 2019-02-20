using CommandBus.CommandBusCore.Commands;
using CommandBus.CommandBusCore.MessageRouters;

namespace CommandBus.CommandBusCore.CommandBusses
{
    public class CommandBus : ICommandBus
    {
        private readonly IMessageRouter messageRouter;

        public CommandBus(IMessageRouter messageRouter)
        {
            this.messageRouter = messageRouter;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = this.messageRouter.GetRoute<TCommand>();

            commandHandler.Handle(command);
        }
    }
}
