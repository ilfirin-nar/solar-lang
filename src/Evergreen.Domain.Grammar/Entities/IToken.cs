using Evergreen.Domain.Grammar.GlobalStateObjects;
using Evergreen.Infrastructure.Common.Interfaces.DomainLayer;

namespace Evergreen.Domain.Grammar.Entities
{
    public interface IToken : IAggregationRootEntity
    {
        string Value { get; }

        ITokenType Type { get; }        
    }
}