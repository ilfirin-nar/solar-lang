using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.Common.Services
{
    public interface IMapper<in TSource, out TTarget> : IMapper
        where TSource : class
        where TTarget : class, new()
    {
        TTarget Map(TSource source);
    }
}