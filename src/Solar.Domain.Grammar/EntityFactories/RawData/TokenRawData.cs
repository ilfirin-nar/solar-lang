using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes;
using Solar.Infrastructure.Common.Extensions;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.EntityFactories.RawData
{
    public class TokenRawData : IEntityRawData
    {
        public TokenRawData(string lexeme)
        {
            Lexeme = lexeme;
        }

        public TokenRawData(string lexeme, ITokenType tokenType)
        {
            Lexeme = lexeme;
            TokenType = tokenType;
        }

        public string Lexeme { get; set; }

        public ITokenType TokenType { get; set; }

        public bool IsEmpty => Lexeme.IsEmpty();
    }
}