using Application.Queries.Customers;
using Contracts.Repositories.Customers;
using MediatR;
using global::Ninject;
using global::Ninject.Modules;
using global::Ninject.Extensions.Conventions;
using Infrastructure.Repositories.Customers;

namespace MediatRTesting.Composition
{
    public class MediatRTestingModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICustomerCommandRepository>().To<CustomerCommandRepository>().InSingletonScope();
            this.Bind<ICustomerQueryRepository>().To<CustomerQueryRepository>().InSingletonScope();
            
            this.Bind(scan => scan.FromAssemblyContaining<IMediator>().SelectAllClasses().BindDefaultInterface());
            this.Bind(scan => scan.FromAssemblyContaining<GetCustomerById.Query>().SelectAllClasses().InheritedFrom(typeof(IRequestHandler<,>)).BindAllInterfaces());
            this.Bind<ServiceFactory>().ToMethod(ctx => t => ctx.Kernel.TryGet(t));
        }
    }
}
