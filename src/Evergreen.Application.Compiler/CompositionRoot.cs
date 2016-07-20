using System.Reflection;
using LightInject;
using Evergreen.Infrastructure.Common.DependencyInjection.Composition;
using Evergreen.Infrastructure.Common.DependencyInjection.Extensions;
using Evergreen.Infrastructure.Common.DependencyInjection.Registration;
using Evergreen.Infrastructure.Common.Interfaces.ApplicationLayer;

namespace Evergreen.Application.Compiler
{
    internal class CompositionRoot : IEvergreenCompositionRoot
    {
        private static readonly Assembly ThisAssembly = typeof(CompositionRoot).Assembly;

        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IApplicationService>(ThisAssembly, LifeTimeFactory.PerContainer);
        }
    }
}