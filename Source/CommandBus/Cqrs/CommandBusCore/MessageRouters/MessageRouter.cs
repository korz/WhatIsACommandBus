using Cqrs.CommandBusCore.CommandHandlers;
using Cqrs.CommandBusCore.Commands;
using Cqrs.CommandBusCore.Queries;
using Cqrs.CommandBusCore.QueryHandlers;
using Ninject;

namespace Cqrs.CommandBusCore.MessageRouters
{
    public class MessageRouter : IMessageRouter
    {
        private readonly IKernel kernel;

        public MessageRouter(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommandHandler<TCommand> GetRoute<TCommand>() where TCommand : ICommand
        {
            return this.kernel.Get<ICommandHandler<TCommand>>();
        }

        public IQueryHandler<TQuery, TResult> GetRoute<TQuery, TResult>() where TQuery : IQuery<TResult>
        {
            return this.kernel.Get<IQueryHandler<TQuery, TResult>>();
        }
    }
}
