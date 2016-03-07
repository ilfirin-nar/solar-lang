using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes;
using Solar.Domain.Grammar.ValueObjects;

namespace Solar.Domain.Grammar.Entities
{
    public class Token : IToken
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