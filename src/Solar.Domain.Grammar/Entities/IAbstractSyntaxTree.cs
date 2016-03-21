using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Entities
{
    public interface IAbstractSyntaxTree : IEntity
    {       
        IToken Root { get; }

        int NodesCount { get; }
    }
}