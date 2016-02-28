using System.Collections.Generic;

namespace Solar.Infrastructure.Common.Interfaces.DomainLayer
{
    public interface IEntityFactory<out TEntity> : IDomainService
        where TEntity : IEntity
    {
        TEntity Produce();

        IEnumerable<TEntity> Manufacture();
    }
}