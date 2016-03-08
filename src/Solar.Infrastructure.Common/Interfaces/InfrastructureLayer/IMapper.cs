namespace Solar.Infrastructure.Common.Interfaces.InfrastructureLayer
{
    public interface IMapper : IInfrastructureService {}

    public interface IMapper<in TSource, out TTarget> : IMapper
        where TSource : IDataTransferObject
        where TTarget : IDataTransferObject
    {
        TTarget Map(TSource dto);
    }
}