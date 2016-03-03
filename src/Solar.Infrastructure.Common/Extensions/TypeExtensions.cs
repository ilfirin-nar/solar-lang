using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Solar.Infrastructure.Common.Extensions
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

        public static IList<MethodInfo> GetStaticMethods(this Type type)
        {
            return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).ToList();
        }
    }
}