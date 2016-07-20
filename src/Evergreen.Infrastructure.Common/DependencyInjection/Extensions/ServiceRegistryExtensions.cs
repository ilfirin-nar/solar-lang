using System;
using System.Reflection;
using Evergreen.Infrastructure.Common.DependencyInjection.Registration;
using LightInject;

namespace Evergreen.Infrastructure.Common.DependencyInjection.Extensions
{
    public static class ServiceRegistryExtensions
    {
        public static void Register<TInterface>(this IServiceRegistry serviceRegistry, Assembly assembly, Func<ILifetime> lifetimeFactory = null)
        {
            serviceRegistry.RegisterAssembly(assembly, lifetimeFactory ?? LifeTimeFactory.PerScope, ServiceRegistrationFilter.ShouldImplements<TInterface>);
        }
    }
}