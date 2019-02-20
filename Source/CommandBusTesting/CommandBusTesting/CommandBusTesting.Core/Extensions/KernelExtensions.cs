#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="KernelExtensions.cs" company="United Shore Financial Services LLC.">
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

using Ninject;
using Ninject.Extensions.Conventions;

namespace CommandBusTesting.Core.Extensions
{
    public static class KernelExtensions
    {
        public static void BindCommandHandlers(this IKernel kernel, Assembly assembly)
        {
            kernel.BindAllInterfaces(assembly, typeof(ICommandHandler<>));
        }

        public static void BindCommandHandlers(this IKernel kernel, IList<Assembly> assemblies)
        {
            kernel.BindAllInterfaces(assemblies, typeof(ICommandHandler<>));
        }

        public static void BindQueryHandlers(this IKernel kernel, Assembly assembly)
        {
            kernel.BindAllInterfaces(assembly, typeof(IQueryHandler<,>));
        }

        public static void BindQueryHandlers(this IKernel kernel, IList<Assembly> assemblies)
        {
            kernel.BindAllInterfaces(assemblies, typeof(IQueryHandler<,>));
        }

        public static void BindAllInterfaces(this IKernel kernel, IList<Assembly> assemblies, Type type)
        {
            foreach (var assembly in assemblies)
            {
                kernel.BindAllInterfaces(assembly, type);
            }
        }

        public static void BindAllInterfaces(this IKernel kernel, Assembly assembly, Type type)
        {
            kernel.Bind(context =>
            {
                context.From(assembly)
                .SelectAllClasses()
                .InheritedFrom(type)
                .BindAllInterfaces()
                .Configure(config => config.InSingletonScope());
            });
        }
    }
}
