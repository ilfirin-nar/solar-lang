using System.Collections.Generic;
using System.Linq;

namespace Solar.Infrastructure.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static ISet<T> ToHashSet<T>(this IEnumerable<T> enumerable)
        {
            return new HashSet<T>(enumerable);
        }

        public static ISet<T> ToSortedSet<T>(this IEnumerable<T> enumerable)
        {
            return new SortedSet<T>(enumerable);
        }

        public static IEnumerable<T> ExceptItmes<T>(this IEnumerable<T> enumerable, params T[] items)
        {
            return enumerable.Except(items);
        }

        public static bool ContainsOneElement<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Count() == 1;
        }
    }
}