using CommandBus.CommandBusCore.CommandHandlers;
using CommandBus.CommandBusCore.Commands;
using Ninject;

namespace CommandBus.CommandBusCore.MessageRouters
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
    }
}
