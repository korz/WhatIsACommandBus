using System.Collections.Generic;
using System.Reflection;
using Ninject;

namespace Cqrs.Composition
{
    public static class CompositionRoot
    {
        public static readonly IKernel Kernel;

        static CompositionRoot()
        {
            Kernel = new StandardKernel();

            Kernel.Load<CommandBusSampleModule>();

            var handlerAssemblies = new List<Assembly> { typeof(CompositionRoot).Assembly };
            Kernel.BindCommandHandlers(handlerAssemblies);
            Kernel.BindQueryHandlers(handlerAssemblies);
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
