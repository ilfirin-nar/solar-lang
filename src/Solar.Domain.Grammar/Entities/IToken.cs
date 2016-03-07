using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes;
using Solar.Domain.Grammar.ValueObjects;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Entities
{
    public interface IToken : IAggregationRoot
    {
        Lexeme Lexeme { get; }

        ITokenType Type { get; }
    }
}