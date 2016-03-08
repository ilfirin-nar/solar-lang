using System;
using Solar.Infrastructure.Common.Extensions;

namespace Solar.Infrastructure.Common.DependencyInjection.Registration
{
    public static class ServiceRegistrationFilter
    {
        public static bool ShouldImplements<TInterface>(Type interfaceType, Type implementingType)
        {
            var type = typeof(TInterface);
            return (interfaceType == type || interfaceType.IsImplements<TInterface>()) && implementingType.IsImplements<TInterface>();
        }
    }
}