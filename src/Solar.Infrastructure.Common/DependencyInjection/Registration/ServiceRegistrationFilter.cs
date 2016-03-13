using System;
using Solar.Infrastructure.Common.Extensions;

namespace Solar.Infrastructure.Common.DependencyInjection.Registration
{
    public static class ServiceRegistrationFilter
    {
        public static bool ShouldImplements<TInterface>(Type serviceType, Type implementingType)
        {
            return
                serviceType.IsImplements<TInterface>() &&
                (
                    implementingType.IsDirectImplementationOf(serviceType) ||
                    implementingType.IsDirectImplementationOf(typeof(TInterface))
                );
        }
    }
}