using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Util;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Autofac
{
    public static class AutofacBuilderHelper
    {
        public static IServiceProvider UseIoc(this IServiceCollection services, Type entryType)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            RegisterTypes(entryType.Assembly, builder);
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        private static void RegisterTypes(Assembly assembly, ContainerBuilder builder)
        {
            var types = assembly.GetLoadableTypes();
            foreach (var type in types)
            {
                var dependency = type.GetCustomAttribute<DependsOnAttribute>();
                if (dependency != null)
                {
                    RegisterTypes(dependency.Type.Assembly, builder);
                }
            }
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => (t.GetInterfaces()?.Contains(typeof(ISingleton)) ?? false) && !t.IsAbstract && !t.IsInterface)
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
