using System.Reflection;
using LightInject;
using Solar.Domain.Grammar.Lexical.TokenTypes;
using Solar.Infrastructure.Common.DependencyInjection;
using Solar.Infrastructure.Common.DependencyInjection.Extensions;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar
{
    internal class CompositionRoot : ISolarCompositionRoot
    {
        private static readonly Assembly ThisAssembly = typeof(CompositionRoot).Assembly;

        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IEntityBehaviorService>(ThisAssembly, LifeTimeFactory.PerContainer);
            serviceRegistry.Register<IDomainService>(ThisAssembly, LifeTimeFactory.PerContainer);
            serviceRegistry.Register<ITokenType>(ThisAssembly, LifeTimeFactory.PerContainer);
        }
    }
}