using System.Collections.Generic;

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
    }
}