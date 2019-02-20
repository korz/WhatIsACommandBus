using Ninject;

namespace MediatRTesting.Composition
{
    /// <summary>
    /// Static instance of the Ninject Kernel
    /// </summary>
    public static class CompositionRoot
    {
        /// <summary>
        /// The Kernel used by Ninject to hold bindings and instances of objects
        /// </summary>
        public static readonly IKernel Kernel;

        /// <summary>
        /// Sets up the Kernel and loads all relevant modules
        /// </summary>
        static CompositionRoot()
        {
            Kernel = new StandardKernel();

            AssignKernels();
            LoadModules();
        }

        /// <summary>
        /// Passes the kernel into other composition roots
        /// </summary>
        public static void AssignKernels()
        {
        }

        /// <summary>
        /// Loads binding modules into the kernel
        /// </summary>
        public static void LoadModules()
        {
            Kernel.Load<MediatRTestingModule>();
        }

        /// <summary>
        /// Gets an instance of <typeparam name="T"> from the kernel</typeparam>
        /// </summary>
        /// <typeparam name="T">the type to get</typeparam>
        /// <returns>an instance of <typeparam name="T"></typeparam></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
