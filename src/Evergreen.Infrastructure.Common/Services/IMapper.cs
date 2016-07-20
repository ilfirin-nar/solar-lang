using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Evergreen.Infrastructure.Common.Services
{
    public interface IMapper<in TSource, out TTarget> : IMapper
        where TSource : class
        where TTarget : class, new()
    {
        TTarget Map(TSource source);
    }
}