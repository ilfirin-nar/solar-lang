using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes;
using Solar.Domain.Grammar.ValueObjects;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Entities
{
    public class Token : IAggregationRoot
    {
        public Token(Lexeme lexeme, ITokenType type)
        {
            Lexeme = lexeme;
            Type = type;
        }

        public Lexeme Lexeme { get; private set; }

        public ITokenType Type { get; private set; }
    }
}