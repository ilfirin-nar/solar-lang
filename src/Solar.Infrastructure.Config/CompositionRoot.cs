using System.Reflection;
using LightInject;
using Solar.Infrastructure.Common.DependencyInjection.Composition;
using Solar.Infrastructure.Common.DependencyInjection.Extensions;
using Solar.Infrastructure.Common.DependencyInjection.Registration;
using Solar.Infrastructure.Common.Interfaces;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Solar.Infrastructure.Config.DataTransferObjects;

namespace Solar.Infrastructure.Config
{
    internal class CompositionRoot : ISolarCompositionRoot
    {
        private static readonly Assembly ThisAssembly = typeof(CompositionRoot).Assembly;

        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IService>(ThisAssembly, LifeTimeFactory.PerContainer);
            serviceRegistry.Register<IConfigSection>(ThisAssembly, LifeTimeFactory.PerContainer);
            serviceRegistry.Register<IGlobalStateObject>(ThisAssembly, LifeTimeFactory.PerContainer);
        }
    }
}