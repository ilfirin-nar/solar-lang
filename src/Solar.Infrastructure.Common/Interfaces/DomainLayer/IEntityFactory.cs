using System.Collections.Generic;

namespace Solar.Infrastructure.Common.Interfaces.DomainLayer
{
    public interface IEntityFactory<out TEntity, in TEntityRawData> : IDomainService
        where TEntity : IEntity
        where TEntityRawData : IEntityRawData
    {
        TEntity Produce(TEntityRawData rawData);

        IEnumerable<TEntity> Manufacture(IEnumerable<TEntityRawData> rawData);
    }
}