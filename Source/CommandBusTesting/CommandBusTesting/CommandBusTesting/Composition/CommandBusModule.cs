#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="CommandBusModule.cs" company="United Shore Financial Services LLC.">
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

using Ninject.Modules;

using Serilog;

namespace CommandBusTesting.Composition
{
    public class CommandBusModule : NinjectModule
    {
        public override void Load()
        {
			//this.Bind<ICommandHandler<SampleCommand>>().To<SampleCommandHandler>().InSingletonScope();
			//this.Bind<ICommandHandler<SampleCommand2>>().To<SampleCommand2Handler>().InSingletonScope();

			this.Bind<ILogger>().ToMethod(context =>
                new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger()).InSingletonScope();
        }
    }
}
