﻿using System.Reflection;
using Evergreen.Infrastructure.Common.DependencyInjection.Composition;
using Evergreen.Infrastructure.Common.DependencyInjection.Extensions;
using Evergreen.Infrastructure.Common.DependencyInjection.Registration;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Evergreen.Infrastructure.ErrorHandling.Interceptors;
using LightInject;

namespace Evergreen.Infrastructure.ErrorHandling
{
    internal class CompositionRoot : IEvergreenCompositionRoot
    {
        private static readonly Assembly ThisAssembly = typeof(CompositionRoot).Assembly;

        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IInfrastructureService>(ThisAssembly, LifeTimeFactory.PerContainer);
            serviceRegistry.Register<IErrorHandlingInterceptor, ErrorHandlingInterceptor>();
        }
    }
}