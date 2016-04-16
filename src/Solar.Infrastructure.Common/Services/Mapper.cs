using System;

namespace Solar.Infrastructure.Common.Services
{
    internal class Mapper<TSource, TTarget> : IMapper<TSource, TTarget>
        where TSource : class
        where TTarget : class, new()
    {
        private static readonly Func<TSource, TTarget> ProduceMapping;

        static Mapper()
        {
            ProduceMapping = MapFunctionGenerator<TSource, TTarget>.Generate();
        }

        public TTarget Map(TSource source)
        {
            return ProduceMapping(source);
        }
    }
}