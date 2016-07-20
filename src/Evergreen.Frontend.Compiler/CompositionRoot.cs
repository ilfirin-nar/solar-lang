using System.Reflection;
using LightInject;
using Evergreen.Infrastructure.Common.DependencyInjection.Composition;
using Evergreen.Infrastructure.Common.DependencyInjection.Extensions;
using Evergreen.Infrastructure.Common.DependencyInjection.Registration;
using Evergreen.Infrastructure.Common.Interfaces.FrontendLayer;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Evergreen.Infrastructure.ErrorHandling.Interceptors;

namespace Evergreen.Frontend.Compiler
{
    internal class CompositionRoot : IEvergreenCompositionRoot
    {
        private static readonly Assembly ThisAssembly = typeof(CompositionRoot).Assembly;

        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IInfrastructureService>(ThisAssembly, LifeTimeFactory.PerContainer);
            serviceRegistry.Register<IFrontendService>(ThisAssembly, LifeTimeFactory.PerContainer);
            serviceRegistry.Intercept(sr => sr.ServiceType == typeof(IConsoleProgram), sf => sf.GetInstance<IErrorHandlingInterceptor>());
        }
    }
}