using System.Collections.Generic;
using System.Linq;
using Solar.Domain.Grammar.Entities;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Brackets;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Syntax
{
    public interface IGrammarRule : IValueObject
    {
        bool IsMatch(IReadOnlyList<IToken> tokens);
    }

    internal class DeclarationScopeGrammarRule : IGrammarRule
    {
        private readonly IReadOnlyList<ITokenType> _characteristicTokenConsequence;

        public DeclarationScopeGrammarRule(IReadOnlyList<BracketTokenType> bracketTokenTypes)
        {
            _characteristicTokenConsequence = new List<ITokenType>
            {
                bracketTokenTypes.Single(t => t is LeftSquareBracketTokenType),
                bracketTokenTypes.Single(t => t is RightParenthesisTokenType)
            };
        }

        public bool IsMatch(IReadOnlyList<IToken> tokens)
        {
            throw new System.NotImplementedException();
        }
    }
}