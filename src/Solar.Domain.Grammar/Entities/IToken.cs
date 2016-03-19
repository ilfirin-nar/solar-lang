using System.Collections.Generic;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Entities
{
    public interface IToken : IAggregationRoot
    {
        string Lexeme { get; }

        ITokenType Type { get; }

        IReadOnlyList<IToken> InnerTokens { get; }
    }
}