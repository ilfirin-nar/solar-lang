using System.Reflection;
using Evergreen.Infrastructure.Common.DependencyInjection.Composition;
using Evergreen.Infrastructure.Common.DependencyInjection.Extensions;
using Evergreen.Infrastructure.Common.DependencyInjection.Registration;
using Evergreen.Infrastructure.Common.Interfaces;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using LightInject;

namespace Evergreen.Infrastructure.Configuration
{
    internal class CompositionRoot : IEvergreenCompositionRoot
    {
        private static readonly Assembly ThisAssembly = typeof(CompositionRoot).Assembly;

        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IService>(ThisAssembly, LifeTimeFactory.PerContainer);
            serviceRegistry.Register<IGlobalStateObject>(ThisAssembly, LifeTimeFactory.PerContainer);
        }
    }
}