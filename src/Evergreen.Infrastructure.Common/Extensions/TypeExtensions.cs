using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Evergreen.Infrastructure.Common.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsImplements<TInterface>(this Type type)
        {
            var interfaceType = typeof(TInterface);
            return type.IsImplements(interfaceType);
        }

        private static bool IsImplements(this Type type, Type interfaceType)
        {
            return type.GetInterfaces().Any(it => it == interfaceType);
        }

        public static bool IsDirectImplementationOf(this Type implementingType, Type type)
        {
            var minimalInterfaces = implementingType.GetDirectInterfaces();
            return minimalInterfaces.Any(mit => mit == type);
        }

        private static IEnumerable<Type> GetDirectInterfaces(this Type type)
        {
            var allInterfaces = type.GetInterfaces();
            return allInterfaces.Except(allInterfaces.SelectMany(t => t.GetInterfaces()));
        }

        public static IEnumerable<MethodInfo> GetStaticMethods(this Type type)
        {
            return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        }
    }
}