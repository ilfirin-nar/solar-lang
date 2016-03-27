using Solar.Domain.Grammar.GlobalStateObjects;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Entities
{
    public interface IToken : IAggregationRootEntity
    {
        string Value { get; }

        ITokenType Type { get; }        
    }
}