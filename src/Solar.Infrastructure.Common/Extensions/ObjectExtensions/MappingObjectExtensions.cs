using Omu.ValueInjecter;

namespace Solar.Infrastructure.Common.Extensions.ObjectExtensions
{
    public static class MappingObjectExtension
    {
        public static void Map(this object target, object source)
        {
            target.InjectFrom(source);
        }

        public static TTarget Map<TTarget>(this object target, object source)
        {
            return (TTarget) target.InjectFrom(source);
        }
    }
}