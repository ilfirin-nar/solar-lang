using System.Reflection;
using LightInject;
using Solar.Infrastructure.Common.DependencyInjection.Composition;
using Solar.Infrastructure.Common.DependencyInjection.Extensions;
using Solar.Infrastructure.Common.DependencyInjection.Registration;
using Solar.Infrastructure.Common.Interfaces.FrontendLayer;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Solar.Infrastructure.ErrorHandling.Interceptors;

namespace Solar.Infrastructure.ErrorHandling
{
    internal class CompositionRoot : ISolarCompositionRoot
    {
        private static readonly Assembly ThisAssembly = typeof(CompositionRoot).Assembly;

        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IInfrastructureService>(ThisAssembly, LifeTimeFactory.PerContainer);
            serviceRegistry.Register<IErrorHandlingInterceptor, ErrorHandlingInterceptor>();
            serviceRegistry.Intercept(sr => sr.ServiceType == typeof(IConsoleProgram), sf => sf.GetInstance<IErrorHandlingInterceptor>());
        }
    }
}