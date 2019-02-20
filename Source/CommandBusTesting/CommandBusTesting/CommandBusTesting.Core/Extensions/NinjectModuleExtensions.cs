#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="NinjectModuleExtensions.cs" company="United Shore Financial Services LLC.">
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

using System;
using System.Collections.Generic;
using System.Reflection;

using CommandBusTesting.Core.CommandHandlers;
using CommandBusTesting.Core.QueryHandlers;

using Ninject.Modules;

namespace CommandBusTesting.Core.Extensions
{
    public static class NinjectModuleExtensions
    {
        public static void BindCommandHandlers(this INinjectModule module, Assembly assembly)
        {
            module.Kernel.BindCommandHandlers(assembly);
        }

        public static void BindCommandHandlers(this INinjectModule module, IList<Assembly> assemblies)
        {
            module.Kernel.BindCommandHandlers(assemblies);
        }

        public static void BindQueryHandlers(this INinjectModule module, Assembly assembly)
        {
            module.Kernel.BindQueryHandlers(assembly);
        }

        public static void BindQueryHandlers(this INinjectModule module, IList<Assembly> assemblies)
        {
            module.Kernel.BindQueryHandlers(assemblies);
        }

        public static void BindAllInterfaces(this INinjectModule module, IList<Assembly> assemblies, Type type)
        {
            module.Kernel.BindAllInterfaces(assemblies, type);
        }

        public static void BindAllInterfaces(this INinjectModule module, Assembly assembly, Type type)
        {
            module.Kernel.BindAllInterfaces(assembly, type);
        }
    }
}
