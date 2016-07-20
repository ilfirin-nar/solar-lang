using System;
using Evergreen.Infrastructure.Common.Extensions;

namespace Evergreen.Infrastructure.Common.DependencyInjection.Registration
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