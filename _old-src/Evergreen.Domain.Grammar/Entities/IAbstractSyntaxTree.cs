using Evergreen.Infrastructure.Common.Interfaces.DomainLayer;

namespace Evergreen.Domain.Grammar.Entities
{
    public interface IAbstractSyntaxTree : IEntity
    {       
        IToken Root { get; }

        int NodesCount { get; }
    }
}