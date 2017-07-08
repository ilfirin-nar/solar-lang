using System;
using System.Linq;
using System.Reflection;

namespace Evergreen.Infrastructure.Common.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static bool HasAttribute<TAttribute>(this PropertyInfo propertyInfo)
            where TAttribute : Attribute
        {
            return propertyInfo.GetCustomAttributes<TAttribute>().Any();
        }
    }
}