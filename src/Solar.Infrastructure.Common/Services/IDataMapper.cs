using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.Common.Services
{
    public interface IDataMapper<in TSource, out TTarget> : IMapper
        where TSource : IDataTransferObject
        where TTarget : IDataTransferObject
    {
        TTarget Map(TSource dto);
    }
}