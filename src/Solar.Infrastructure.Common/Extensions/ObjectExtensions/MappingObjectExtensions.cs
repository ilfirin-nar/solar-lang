using Omu.ValueInjecter;

namespace Solar.Infrastructure.Common.Extensions.ObjectExtensions
{
    public static class MappingObjectExtension
    {
        public static void Map<TSource, TTarget>(this TTarget target, TSource source)
        {
            target.InjectFrom(source);
        }
    }
}