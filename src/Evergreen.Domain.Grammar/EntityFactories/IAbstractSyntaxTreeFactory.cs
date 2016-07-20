using System.Collections.Generic;
using Evergreen.Domain.Grammar.Entities;
using Evergreen.Infrastructure.Common.Interfaces.DomainLayer;

namespace Evergreen.Domain.Grammar.EntityFactories
{
    public interface IAbstractSyntaxTreeFactory : IEntityFactory
    {
        IAbstractSyntaxTreeFactory Produce(IReadOnlyList<IToken> tokens);
    }
}