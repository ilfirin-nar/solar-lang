using System.Collections.Generic;
using Solar.Domain.Grammar.Entities;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.EntityFactories
{
    public interface IAbstractSyntaxTreeFactory : IEntityFactory
    {
        IAbstractSyntaxTreeFactory Produce(IReadOnlyList<IToken> tokens);
    }
}