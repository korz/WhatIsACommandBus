using Cqrs.CommandBusCore.CommandBusses;
using Cqrs.CommandBusCore.CommandHandlers;
using Cqrs.CommandBusCore.MessageRouters;
using Cqrs.CommandHandlers;
using Cqrs.Commands;
using Cqrs.Repositories;
using Ninject.Modules;

namespace Cqrs.Composition
{
    public class CommandBusSampleModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICommandBus>().To<Cqrs.CommandBusCore.CommandBusses.CommandBus>().InSingletonScope();
            this.Bind<IMessageRouter>().ToMethod(ctx => new MessageRouter(this.Kernel)).InSingletonScope();
            this.Bind<ICustomerQueryRepository>().To<CustomerQueryRepository>().InSingletonScope();

            //this.Bind<ICommandHandler<InactivateCustomerCommand>>().To<InactivateCustomerCommandHandler>().InSingletonScope();
            //this.Bind<ICommandHandler<ActivateCustomerCommand>>().To<ActivateCustomerCommand>().InSingletonScope();
            //this.Bind<ICommandHandler<DeleteCustomerCommand>>().To<DeleteCustomerCommand>().InSingletonScope();
            //this.Bind<ICommandHandler<CreateCustomerCommand>>().To<CreateCustomerCommand>().InSingletonScope();
            //this.Bind<ICommandHandler<UpdateCustomerCommand>>().To<UpdateCustomerCommand>().InSingletonScope();
        }
    }
}
