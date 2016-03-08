namespace Solar.Infrastructure.Common.Interfaces.InfrastructureLayer
{
    public interface IMapper<in TSource, out TTarget> : IInfrastructureService
        where TSource : IDataTransferObject
        where TTarget : IDataTransferObject
    {
        TTarget Map(TSource dto);
    }
}