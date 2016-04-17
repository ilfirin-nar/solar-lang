using Solar.Infrastructure.Common.StaticServices;

namespace Solar.Infrastructure.Common.Extensions.ObjectExtensions
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