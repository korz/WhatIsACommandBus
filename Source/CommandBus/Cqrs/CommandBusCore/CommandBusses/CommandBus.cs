using Cqrs.CommandBusCore.Commands;
using Cqrs.CommandBusCore.MessageRouters;
using Cqrs.CommandBusCore.Queries;

namespace Cqrs.CommandBusCore.CommandBusses
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

        public TResult Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var queryHandler = this.messageRouter.GetRoute<TQuery, TResult>();

            return queryHandler.Handle(query);
        }
    }
}
