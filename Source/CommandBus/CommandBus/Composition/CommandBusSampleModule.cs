using CommandBus.CommandBusCore.CommandBusses;
using CommandBus.CommandBusCore.CommandHandlers;
using CommandBus.CommandBusCore.MessageRouters;
using CommandBus.CommandHandlers;
using CommandBus.Commands;
using CommandBus.Repositories;
using Ninject.Modules;

namespace CommandBus.Composition
{
    public class CommandBusSampleModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICommandBus>().To<CommandBusCore.CommandBusses.CommandBus>().InSingletonScope();
            this.Bind<IMessageRouter>().ToMethod(ctx => new MessageRouter(this.Kernel)).InSingletonScope();
            this.Bind<ICustomerRepository>().To<CustomerRepository>().InSingletonScope();

            this.Bind<ICommandHandler<InactivateCustomerCommand>>().To<InactivateCustomerCommandHandler>().InSingletonScope();
        }

        private void OtherBindings()
        {
            //this.Bind<ICommandHandler<ActivateCustomerCommand>>().To<ActivateCustomerCommand>().InSingletonScope();
            //this.Bind<ICommandHandler<DeleteCustomerCommand>>().To<DeleteCustomerCommand>().InSingletonScope();
            //this.Bind<ICommandHandler<CreateCustomerCommand>>().To<CreateCustomerCommand>().InSingletonScope();
            //this.Bind<ICommandHandler<UpdateCustomerCommand>>().To<UpdateCustomerCommand>().InSingletonScope();
        }
    }
}
