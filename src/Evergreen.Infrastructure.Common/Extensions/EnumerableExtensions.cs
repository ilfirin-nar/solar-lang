using System.Collections.Generic;
using System.Linq;

namespace Evergreen.Infrastructure.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ExceptItems<T>(this IEnumerable<T> enumerable, params T[] items)
        {
            return enumerable.Except(items);
        }
    }
}