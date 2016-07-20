using System.Collections.Generic;

namespace Evergreen.Infrastructure.Common.Interfaces.DomainLayer
{
    public interface IEntityFactory : IDomainService {}

    public interface IEntityFactory<out TEntity, in TEntityRawData> : IEntityFactory
        where TEntity : IEntity
        where TEntityRawData : IEntityRawData
    {
        TEntity Produce(TEntityRawData rawData);

        IEnumerable<TEntity> Manufacture(IEnumerable<TEntityRawData> rawData);
    }
}