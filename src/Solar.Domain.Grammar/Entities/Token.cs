using System.Collections.Generic;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes;

namespace Solar.Domain.Grammar.Entities
{
    public class Token : IToken
    {
        public Token(string lexeme, ITokenType type)
        {
            Lexeme = lexeme;
            Type = type;
        }

        public Token(string lexeme, ITokenType type, IReadOnlyList<IToken> innerTokens)
        {
            Lexeme = lexeme;
            Type = type;
            InnerTokens = innerTokens;
        }

        public string Lexeme { get; }

        public ITokenType Type { get; }

        public IReadOnlyList<IToken> InnerTokens { get; }
    }
}