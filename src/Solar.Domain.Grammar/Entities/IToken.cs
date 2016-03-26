using System.Collections.Generic;
using Solar.Domain.Grammar.GlobalStateObjects;
using Solar.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes;
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