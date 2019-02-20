using Ninject;

namespace CommandBus.Composition
{
    public static class CompositionRoot
    {
        public static readonly IKernel Kernel;

        static CompositionRoot()
        {
            Kernel = new StandardKernel();

            Kernel.Load<CommandBusSampleModule>();
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
