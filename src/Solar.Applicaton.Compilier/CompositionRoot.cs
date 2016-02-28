using System.Reflection;
using LightInject;
using Solar.Infrastructure.Common.DependencyInjection;
using Solar.Infrastructure.Common.DependencyInjection.Extensions;
using Solar.Infrastructure.Common.Interfaces.ApplicationLayer;

namespace Solar.Application.Compilier
{
    internal class CompositionRoot : ISolarCompositionRoot
    {
        private static readonly Assembly ThisAssembly = typeof(CompositionRoot).Assembly;

        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IApplicationService>(ThisAssembly, LifeTimeFactory.PerContainer);
        }
    }
}