using System;
using System.Collections.Generic;
using System.Reflection;
using Cqrs.CommandBusCore.CommandBusses;
using Cqrs.CommandBusCore.CommandHandlers;
using Cqrs.CommandBusCore.Commands;
using Cqrs.CommandBusCore.Queries;
using Cqrs.CommandBusCore.QueryHandlers;
using Newtonsoft.Json;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace Cqrs
{
    public static class Extensions
    {
        public static string ToJson<T>(this T entity)
        {
            return JsonConvert.SerializeObject(entity);
        }

        public static void BindCommandHandlers(this INinjectModule module, Assembly assembly)
        {
            module.Kernel.BindCommandHandlers(assembly);
        }

        public static void BindCommandHandlers(this IKernel kernel, Assembly assembly)
        {
            kernel.BindAllInterfaces(assembly, typeof(ICommandHandler<>));
        }

        public static void BindCommandHandlers(this INinjectModule module, IList<Assembly> assemblies)
        {
            module.Kernel.BindCommandHandlers(assemblies);
        }

        public static void BindCommandHandlers(this IKernel kernel, IList<Assembly> assemblies)
        {
            kernel.BindAllInterfaces(assemblies, typeof(ICommandHandler<>));
        }

        public static void BindAllInterfaces(this INinjectModule module, IList<Assembly> assemblies, Type type)
        {
            module.Kernel.BindAllInterfaces(assemblies, type);
        }

        public static void BindAllInterfaces(this IKernel kernel, IList<Assembly> assemblies, Type type)
        {
            foreach (var assembly in assemblies)
            {
                kernel.BindAllInterfaces(assembly, type);
            }
        }

        public static void BindAllInterfaces(this INinjectModule module, Assembly assembly, Type type)
        {
            module.Kernel.BindAllInterfaces(assembly, type);
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

        public static void BindQueryHandlers(this INinjectModule module, Assembly assembly)
        {
            module.Kernel.BindQueryHandlers(assembly);
        }

        public static void BindQueryHandlers(this INinjectModule module, IList<Assembly> assemblies)
        {
            module.Kernel.BindQueryHandlers(assemblies);
        }

        public static void BindQueryHandlers(this IKernel kernel, Assembly assembly)
        {
            kernel.BindAllInterfaces(assembly, typeof(IQueryHandler<,>));
        }

        public static void BindQueryHandlers(this IKernel kernel, IList<Assembly> assemblies)
        {
            kernel.BindAllInterfaces(assemblies, typeof(IQueryHandler<,>));
        }

        public static void SendCommand<TCommand>(this TCommand command, ICommandBus commandBus) where TCommand : ICommand
        {
            commandBus.Send(command);
        }

        public static void SendQuery<TQuery, TResult>(this TQuery query, ICommandBus commandBus) where TQuery : IQuery<TResult>
        {
            commandBus.Send<TQuery, TResult>(query);
        }

        public static void SendQuery<TQuery, TResult>(this IQuery<TResult> query, ICommandBus commandBus) where TQuery : IQuery<TResult>
        {
            commandBus.Send<TQuery, TResult>(query as TQuery);
        }
    }
}
