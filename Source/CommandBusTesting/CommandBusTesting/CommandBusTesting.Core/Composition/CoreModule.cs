#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="CoreModule.cs" company="United Shore Financial Services LLC.">
//     Copyright &copy; United Shore Financial Services Inc. 2012-2017.
// 
//     Copyright in the application source code, and in the information and
//     material therein and in their arrangement, is owned by United Shore Financial Services LLC.
//     unless otherwise indicated.
// 
//     You shall not remove or obscure any copyright, trademark or other notices.
//     You may not copy, republish, redistribute, transmit, participate in the
//     transmission of, create derivatives of, alter edit or exploit in any
//     manner any material including by storage on retrieval systems, without the
//     express written permission of United Shore Financial Services LLC.
// </copyright>
//------------------------------------------------------------------------------------------

#endregion

using System.Collections.Generic;
using System.Reflection;

using CommandBusTesting.Core.BindingHandlers;
using CommandBusTesting.Core.CommandBuses;
using CommandBusTesting.Core.Extensions;

using Ninject.Modules;

namespace CommandBusTesting.Core.Composition
{
    public class CoreModule : NinjectModule
    {
        private readonly IList<Assembly> handlerAssemblies;

        public CoreModule(IList<Assembly> handlerAssemblies)
        {
            this.handlerAssemblies = handlerAssemblies;
        }

        public override void Load()
        {
            this.Bind<ICommandBus>().To<CommandBus>().InSingletonScope();

            this.Bind<ICommandHandlerRetreiver>()
                .ToMethod(context => new CommandHandlerRetreiver(context.Kernel))
                .InSingletonScope();

            this.Bind<IQueryHandlerRetreiver>()
                .ToMethod(context => new QueryHandlerRetreiver(context.Kernel))
                .InSingletonScope();

            this.BindCommandHandlers(this.handlerAssemblies);
            this.BindQueryHandlers(this.handlerAssemblies);
        }
    }
}
