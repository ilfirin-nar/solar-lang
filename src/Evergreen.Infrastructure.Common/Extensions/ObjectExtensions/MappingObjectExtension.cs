using Evergreen.Infrastructure.Common.StaticServices;

namespace Evergreen.Infrastructure.Common.Extensions.ObjectExtensions
{
    public static class MappingObjectExtension
    {
        public static void Map<TSource, TTarget>(this TTarget target, TSource source)
            where TTarget : class, new()
        {
            StaticMapper<TSource, TTarget>.Map(source, target);
        }

        public static void MapObject(this object target, object source)
        {
            StaticMapper.Map(source, target);
        }
    }
}