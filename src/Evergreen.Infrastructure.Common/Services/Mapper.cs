using Evergreen.Infrastructure.Common.StaticServices;

namespace Evergreen.Infrastructure.Common.Services
{
    internal class Mapper<TSource, TTarget> : IMapper<TSource, TTarget>
        where TSource : class
        where TTarget : class, new()
    {
        public TTarget Map(TSource source)
        {
            return StaticMapper<TSource, TTarget>.Map(source);
        }
    }
}